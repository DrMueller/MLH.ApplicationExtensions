﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailSending.Services
{
    [TestFixture]
    public class EmailSenderUnitTests
    {
        private Mock<ISmtpClientProxyFactory> _proxyFactoryMock = null!;
        private EmailSender _sut = null!;

        [SetUp]
        public void Align()
        {
            _proxyFactoryMock = new Mock<ISmtpClientProxyFactory>();
            _sut = new EmailSender(_proxyFactoryMock.Object);
        }

        [Test]
        public async Task Sending_CreatesMailMessage_WithpassedValues()
        {
            var email = new Email(
                "matthiasm@live.de",
                new List<string> { "test@gmx.ch" },
                "Test",
                new EmailBody("Test", false));

            var proxyMock = new Mock<ISmtpClientProxy>();
            _proxyFactoryMock.Setup(f => f.CreateProxy()).Returns(proxyMock.Object);

            MailMessage? actualMailMesssage = null;

            proxyMock
                .Setup(f => f.Send(It.IsAny<MailMessage>()))
                .Callback<MailMessage>(msg => actualMailMesssage = msg);

            // Act
            await _sut.SendEmailAsync(email);

            // Assert
            Assert.IsNotNull(actualMailMesssage);
            Assert.AreEqual(email.FromAddress, actualMailMesssage!.From.Address);
            Assert.AreEqual(email.Subject, actualMailMesssage.Subject);
            Assert.AreEqual(email.Body.Content, actualMailMesssage.Body);
            Assert.AreEqual(email.Body.IsHtmlBody, actualMailMesssage.IsBodyHtml);

            var actualToAddresses = actualMailMesssage.To.Select(f => f.Address);
            CollectionAssert.AreEqual(email.ToAddresses, actualToAddresses);
        }

        [Test]
        public async Task Sending_SendsEmail_ToSmtpClient()
        {
            // Arrange
            var email = new Email(
                "matthiasm@live.de",
                new List<string> { "test@gmx.ch" },
                "Test",
                new EmailBody("Test", false));

            var proxyMock = new Mock<ISmtpClientProxy>();
            _proxyFactoryMock.Setup(f => f.CreateProxy()).Returns(proxyMock.Object);

            // Act
            await _sut.SendEmailAsync(email);

            // Assert
            proxyMock.Verify(f => f.Send(It.IsAny<MailMessage>()), Times.Once);
        }
    }
}
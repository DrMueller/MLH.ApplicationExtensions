using System.Linq;
using System.Threading.Tasks;
using MailKit;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants;
using Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailReceiving.Imap.Services.TestServants;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailReceiving.Imap.Services
{
    [TestFixture]
    public class ImapEmailReceiverUnitTests
    {
        private Mock<IImapClientProxyFactory> _proxyFactoryMock = null!;
        private ImapEmailReceiver _sut = null!;

        [SetUp]
        public void Align()
        {
            _proxyFactoryMock = new Mock<IImapClientProxyFactory>();
            _sut = new ImapEmailReceiver(_proxyFactoryMock.Object);
        }

        [Test]
        public async Task RceivingFromInbox_DisconnectsClientProxy_AfterReadingInbox()
        {
            // Arrang
            var proxyMock = new Mock<IImapClientProxy>();
            var mailFolderMock = new Mock<IMailFolder>();
            _proxyFactoryMock.Setup(f => f.CreateAuthenticatedProxyAsync()).Returns(Task.FromResult(proxyMock.Object));
            proxyMock.Setup(f => f.Inbox).Returns(mailFolderMock.Object);

            // Act
            // ReSharper disable once UnusedVariable
            var actualEmails = await _sut.ReceiveFromInboxAsync();

            // Assert
            proxyMock.Verify(f => f.DisconnectAsync(), Times.Once);
        }

        [Test]
        public async Task RceivingFromInbox_MapsEmail_FromMimeMessage()
        {
            // Arrange
            var mimeMessage = MimeMessageFactory.CreateTestMimeMessage(out var expectedEmailValues);

            var proxyMock = new Mock<IImapClientProxy>();
            var mailFolderMock = new Mock<IMailFolder>();

            mailFolderMock.Setup(f => f.Count).Returns(1);
            mailFolderMock.Setup(f => f.GetMessageAsync(0, default, null)).Returns(Task.FromResult(mimeMessage));
            _proxyFactoryMock.Setup(f => f.CreateAuthenticatedProxyAsync()).Returns(Task.FromResult(proxyMock.Object));
            proxyMock.Setup(f => f.Inbox).Returns(mailFolderMock.Object);

            // Act
            var actualEmails = await _sut.ReceiveFromInboxAsync();

            // Assert
            Assert.AreEqual(actualEmails.Count, 1);
            var actualEmail = actualEmails.Single();

            Assert.AreEqual(expectedEmailValues.BodyText, actualEmail.Body);
            Assert.AreEqual(expectedEmailValues.Subject, actualEmail.Subject);
            CollectionAssert.AreEquivalent(expectedEmailValues.FromEmailAddresses, actualEmail.FromAddresses);
            CollectionAssert.AreEquivalent(expectedEmailValues.ToEmailAddresses, actualEmail.ToAddresses);
        }

        [Test]
        public async Task RceivingFromInbox_OpensInbox()
        {
            // Arrange
            var proxyMock = new Mock<IImapClientProxy>();
            var mailFolderMock = new Mock<IMailFolder>();
            _proxyFactoryMock.Setup(f => f.CreateAuthenticatedProxyAsync()).Returns(Task.FromResult(proxyMock.Object));
            proxyMock.Setup(f => f.Inbox).Returns(mailFolderMock.Object);

            // Act
            // ReSharper disable once UnusedVariable
            var actualEmails = await _sut.ReceiveFromInboxAsync();

            // Assert
            proxyMock.Verify(f => f.Inbox, Times.Once);
        }

        [Test]
        public async Task RceivingFromInbox_OpensInbox_WithReadAccess()
        {
            // Arrang
            var proxyMock = new Mock<IImapClientProxy>();
            var mailFolderMock = new Mock<IMailFolder>();

            _proxyFactoryMock.Setup(f => f.CreateAuthenticatedProxyAsync()).Returns(Task.FromResult(proxyMock.Object));
            proxyMock.Setup(f => f.Inbox).Returns(mailFolderMock.Object);

            // Act
            // ReSharper disable once UnusedVariable
            var actualEmails = await _sut.ReceiveFromInboxAsync();

            // Assert
            mailFolderMock.Verify(f => f.OpenAsync(FolderAccess.ReadOnly, default), Times.Once);
        }
    }
}
using System.Collections.Generic;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailSending.Models
{
    [TestFixture]
    public class EmailUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            const string FromAddress = "hello@fake.ch";
            var emptyToAddressList = new List<string>();
            var toAddressList = new List<string> { "test@fake.com" };
            const string Subject = "Subject";
            var emailBody = new EmailBody("Tra", false);

            ConstructorTestBuilderFactory.Constructing<Email>()
                .UsingDefaultConstructor()
                .WithArgumentValues(FromAddress, toAddressList, Subject, emailBody)
                .Maps()
                .ToProperty(f => f.Body).WithValue(emailBody)
                .ToProperty(f => f.FromAddress).WithValue(FromAddress)
                .ToProperty(f => f.Subject).WithValue(Subject)
                .ToProperty(f => f.ToAddresses).WithValue(toAddressList)
                .BuildMaps()
                .WithArgumentValues(null, toAddressList, Subject, emailBody)
                .Fails()
                .WithArgumentValues(FromAddress, emptyToAddressList, Subject, emailBody)
                .Fails()
                .WithArgumentValues(FromAddress, toAddressList, null, emailBody)
                .Fails()
                .WithArgumentValues(FromAddress, toAddressList, Subject, string.Empty)
                .Fails()
                .Assert();
        }
    }
}
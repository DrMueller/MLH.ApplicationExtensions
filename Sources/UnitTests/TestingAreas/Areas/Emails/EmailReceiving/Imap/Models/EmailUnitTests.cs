using System.Collections.Generic;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailReceiving.Imap.Models
{
    [TestFixture]
    public class EmailUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            var emptyAddressList = new List<string>();
            var toAddressList = new List<string> { "test@fake.com" };
            var fromAddressList = new List<string> { "tra@gmx.ch" };

            const string Subject = "Test123";
            const string EmptySubject = "";
            const string Body = "Body1243";

            ConstructorTestBuilderFactory.Constructing<Email>()
                .UsingDefaultConstructor()
                .WithArgumentValues(fromAddressList, toAddressList, Subject, Body)
                .Maps()
                .ToProperty(f => f.Body).WithValue(Body)
                .ToProperty(f => f.Subject).WithValue(Subject)
                .ToProperty(f => f.FromAddresses).WithValues(fromAddressList)
                .ToProperty(f => f.ToAddresses).WithValues(toAddressList)
                .BuildMaps()
                .WithArgumentValues(fromAddressList, emptyAddressList, Subject, Body)
                .Fails()
                .WithArgumentValues(emptyAddressList, toAddressList, Subject, Body)
                .Fails()
                .WithArgumentValues(fromAddressList, toAddressList, EmptySubject, Body)
                .Fails()
                .WithArgumentValues(fromAddressList, toAddressList, null, Body)
                .Fails()
                .WithArgumentValues(fromAddressList, toAddressList, Subject, null)
                .Succeeds()
                .Assert();
        }
    }
}
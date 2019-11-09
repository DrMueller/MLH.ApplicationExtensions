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
            var addressList = new List<string> { "test@fake.com" };

            const string Subject = "Test123";
            const string EmptySubject = "";
            const string Body = "Body1243";
            const string EmptyBody = "";

            ConstructorTestBuilderFactory.Constructing<Email>()
               .UsingDefaultConstructor()
               .WithArgumentValues(addressList, Subject, Body)
               .Maps()
               .ToProperty(f => f.Body).WithValue(Body)
               .ToProperty(f => f.Subject).WithValue(Subject)
               .ToProperty(f => f.FromAddresses).WithValue(addressList)
               .BuildMaps()
               .WithArgumentValues(emptyAddressList, Subject, Body)
               .Fails()
                .WithArgumentValues(null, Subject, Body)
               .Fails()
               .WithArgumentValues(addressList, EmptySubject, Body)
               .Fails()
               .WithArgumentValues(addressList, null, Body)
               .Fails()
               .WithArgumentValues(addressList, Subject, EmptyBody)
               .Succeeds()
               .WithArgumentValues(addressList, Subject, null)
               .Succeeds()
               .Assert();
        }
    }
}
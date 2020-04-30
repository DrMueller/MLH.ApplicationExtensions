using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailSending.Models
{
    [TestFixture]
    public class EmailBodyUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            const string StringContent = "StringContent";
            const bool IsHtmlBody = true;

            ConstructorTestBuilderFactory.Constructing<EmailBody>()
                .UsingDefaultConstructor()
                .WithArgumentValues(StringContent, IsHtmlBody)
                .Maps()
                .ToProperty(f => f.Content).WithValue(StringContent)
                .ToProperty(f => f.IsHtmlBody).WithValue(IsHtmlBody)
                .BuildMaps()
                .Assert();
        }
    }
}
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailReceiving.Imap.Models
{
    [TestFixture]
    public class ImapSettingsUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            const string Host = "Host1234";
            const int Port = 1234;
            const string UserName = "User123";
            const string Password = "Password324";

            ConstructorTestBuilderFactory.Constructing<ImapSettings>()
               .UsingDefaultConstructor()
               .WithArgumentValues(Host, Port, UserName, Password)
               .Maps()
               .ToProperty(f => f.Host).WithValue(Host)
               .ToProperty(f => f.Password).WithValue(Password)
               .ToProperty(f => f.Port).WithValue(Port)
               .ToProperty(f => f.UserName).WithValue(UserName)
               .BuildMaps()
               .WithArgumentValues(string.Empty, Port, UserName, Password)
               .Fails()
               .WithArgumentValues(Host, 0, UserName, Password)
               .Fails()
               .WithArgumentValues(Host, Port, string.Empty, Password)
               .Fails()
               .WithArgumentValues(Host, Port, UserName, string.Empty)
               .Fails()
               .Assert();
        }
    }
}
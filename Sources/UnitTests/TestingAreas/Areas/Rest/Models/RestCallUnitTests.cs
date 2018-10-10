using System;
using System.Collections.Generic;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Rest.Models
{
    [TestFixture]
    public class RestCallUnitTests
    {
        [Test]
        public void Constructor_Works()
        {
            var baseUri = new Uri("https://www.google.ch");
            Maybe<string> resourcePath = "Test";
            const RestCallMethodType MethodType = RestCallMethodType.Get;
            var security = RestSecurity.CreateAnonymous();
            var headers = new RestHeaders(new List<RestHeader>());
            Maybe<object> body = new object();

            ConstructorTestBuilderFactory.Constructing<RestCall>()
                .UsingDefaultConstructor()
                .WithArgumentValues(baseUri, resourcePath, MethodType, security, headers, body)
                .Maps()
                .ToProperty(f => f.BaseUri).WithValue(baseUri)
                .ToProperty(f => f.Body).WithValue(body)
                .ToProperty(f => f.Headers).WithValue(headers)
                .ToProperty(f => f.MethodType).WithValue(MethodType)
                .ToProperty(f => f.ResourcePath).WithValue(resourcePath)
                .ToProperty(f => f.Security).WithValue(security)
                .BuildMaps()
                .Assert();
        }
    }
}
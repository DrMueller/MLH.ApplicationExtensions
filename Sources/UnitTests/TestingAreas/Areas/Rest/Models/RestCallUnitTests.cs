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
            
            CtorTestBuilderFactory.ForType<RestCall>()
                .ForDefaultConstructor()
                .WithArgumentValues(baseUri, resourcePath, MethodType, security, headers, body)
                .MapsToProperty(f => f.BaseUri).WithValue(baseUri)
                .MapsToProperty(f => f.Body).WithValue(body)
                .MapsToProperty(f => f.Headers).WithValue(headers)
                .MapsToProperty(f => f.MethodType).WithValue(MethodType)
                .MapsToProperty(f => f.ResourcePath).WithValue(resourcePath)
                .MapsToProperty(f => f.Security).WithValue(security)
                .Succeeds();
        }
    }
}
using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Rest.Services
{
    [TestFixture]
    public class RestProxyUnitTests
    {
        private RestProxy _sut;

        [Test]
        public void PerformingCall_WithRestCallNull_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _sut.PerformCallAsync<string>(null));
        }

        [SetUp]
        public void SetUp()
        {
            _sut = new RestProxy();
        }
    }
}
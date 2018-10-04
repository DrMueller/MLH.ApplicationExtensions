using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies.Servants;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Rest.Services
{
    [TestFixture]
    public class RestProxyUnitTests
    {
        private Mock<IHttpRequestFactory> _httpRequestFactoryMock;
        private Mock<IRestCallBuilderFactory> _restCallBuilderFactoryMock;
        private RestProxy _sut;

        [Test]
        public void PerformingCall_WithRestCallNull_ThrowsArgumentException()
        {
            // Arrange
            RestCall nullRestCall = null;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _sut.PerformCallAsync<string>(nullRestCall));
        }

        [SetUp]
        public void SetUp()
        {
            _httpRequestFactoryMock = new Mock<IHttpRequestFactory>();
            _restCallBuilderFactoryMock = new Mock<IRestCallBuilderFactory>();
            _sut = new RestProxy(_httpRequestFactoryMock.Object, _restCallBuilderFactoryMock.Object);
        }
    }
}
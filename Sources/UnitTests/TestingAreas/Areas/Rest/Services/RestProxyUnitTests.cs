using System;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Rest.Services
{
    [TestFixture]
    public class RestProxyUnitTests
    {
        private Mock<IRestCallStrategy> _restCallStrategyMock;
        private RestProxy _sut;

        [Test]
        public async Task PerformingCall_WithGetType_CallSendRequestOfGetStrategy()
        {
            // Arrange
            _restCallStrategyMock.Setup(f => f.MethodType).Returns(RestCallMethodType.Get);
            var restCall = new RestCall(new Uri("https://www.google.ch/"), "Tra", RestCallMethodType.Get);

            // Act
            await _sut.PerformCallAsync<string>(restCall);

            // Assert
            _restCallStrategyMock.Verify(f => f.SendRequestAsync(It.IsAny<Uri>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void PerformingCall_WithRestCallNull_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _sut.PerformCallAsync<string>(null));
        }

        [Test]
        public void PerformingCall_WithUnknownStrategyType_ThrowsArgumentException()
        {
            // Arrange
            var restCall = new RestCall(new Uri("https://www.google.ch/"), "Tra", RestCallMethodType.Get);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _sut.PerformCallAsync<string>(restCall));
        }

        [SetUp]
        public void SetUp()
        {
            _restCallStrategyMock = new Mock<IRestCallStrategy>();
            var strategiesArray = new[]
            {
                _restCallStrategyMock.Object
            };

            _sut = new RestProxy(strategiesArray);
        }
    }
}
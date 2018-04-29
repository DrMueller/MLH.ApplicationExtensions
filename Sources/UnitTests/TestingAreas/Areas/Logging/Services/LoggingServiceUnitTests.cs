using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services.Handlers;
using Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services.Implementation;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Logging.Services
{
    [TestFixture]
    public class LoggingServiceUnitTests
    {
        private Mock<ILoggerProxy> _loggerProxyMock;
        private LoggingService _sut;

        [Test]
        public void LoggingError_CallsProxyOnce()
        {
            // Arrange
            var exception = new Exception("Test");
            _loggerProxyMock.Setup(f => f.LogError(It.IsAny<Exception>(), It.IsAny<string>()));

            // Act
            _sut.LogException(exception);

            // Assert
            _loggerProxyMock.Verify(f => f.LogError(exception, It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LoggingError_PassesExceptionMessageAsMessageToProxy()
        {
            // Arrange
            var exception = new Exception("TestHelloWorld");
            string actualMessage = null;
            _loggerProxyMock.Setup(f => f.LogError(exception, It.IsAny<string>())).Callback<Exception, string>(
                (_, str) =>
                {
                    actualMessage = str;
                });

            // Act
            _sut.LogException(exception);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(exception.Message));
        }

        [Test]
        public void LoggingError_PassesExceptionToProxy()
        {
            // Arrange
            var exception = new Exception("Test");
            Exception actualException = null;
            _loggerProxyMock.Setup(f => f.LogError(exception, It.IsAny<string>())).Callback<Exception, string>(
                (ex, _) =>
                {
                    actualException = ex;
                });

            // Act
            _sut.LogException(exception);

            // Assert
            Assert.That(actualException, Is.EqualTo(exception));
        }

        [Test]
        public void LoggingError_WithNullException_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.LogException(null));
        }

        [Test]
        public void LoggingInfo_CallsProxyOnce()
        {
            // Act
            _sut.LogInfo("Doesnt matter");

            // Assert
            _loggerProxyMock.Verify(f => f.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LoggingInfo_PassesMessageToProxy()
        {
            // Arrange
            const string ExpectedMessage = "Test";
            string actualMessage = null;
            _loggerProxyMock.Setup(f => f.LogInformation(It.IsAny<string>())).Callback<string>(
                str =>
                {
                    actualMessage = str;
                });

            // Act
            _sut.LogInfo(ExpectedMessage);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(ExpectedMessage));
        }

        [TestCase("")]
        [TestCase(null)]
        public void LoggingInfo_WithNullOrEmptyString_ThrowsArgumentException(string actual)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.LogInfo(actual));
        }

        [Test]
        public void LoggingWarning_CallsProxyOnce()
        {
            // Act
            _sut.LogWarning("Doesnt matter");

            // Assert
            _loggerProxyMock.Verify(f => f.LogWarning(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LoggingWarning_PassesMessageToProxy()
        {
            // Arrange
            const string ExpectedMessage = "Warning";
            string actualMessage = null;
            _loggerProxyMock.Setup(f => f.LogWarning(It.IsAny<string>())).Callback<string>(
                str =>
                {
                    actualMessage = str;
                });

            // Act
            _sut.LogWarning(ExpectedMessage);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(ExpectedMessage));
        }

        [TestCase("")]
        [TestCase(null)]
        public void LoggingWarning_WithNullOrEmptyString_ThrowsArgumentException(string actual)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.LogWarning(actual));
        }

        [SetUp]
        public void SetUp()
        {
            _loggerProxyMock = new Mock<ILoggerProxy>();
            _sut = new LoggingService(_loggerProxyMock.Object);
        }
    }
}
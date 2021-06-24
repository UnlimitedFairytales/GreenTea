using log4net;
using System;
using System.Reflection;
using Xunit;

namespace UnlimitedFairytales.GreenTea.log4net.Extensions.Tests
{
    public class Log4netExtensionTests
    {
        class DummyClass
        {
        }

        class DummyClass2
        {
        }

        [Fact()]
        public void GetLoggerTest_Parameter()
        {
            {
                // Arrange
                // log4net.config.xml
                var obj = new DummyClass();
                // Act
                var logger = Log4netExtension.GetLogger(obj, "fooLogger");
                // Assert
                Assert.Equal("fooLogger", logger.Logger.Name);
                Assert.Equal(LogManager.GetRepository(Assembly.GetEntryAssembly()), logger.Logger.Repository);
            }
            {
                // Arrange
                // log4net.config.xml
                var obj = new DummyClass();
                // Act
                var logger = Log4netExtension.GetLogger(obj);
                // Assert
                Assert.Equal(typeof(DummyClass).FullName, logger.Logger.Name);
                Assert.Equal(LogManager.GetRepository(Assembly.GetEntryAssembly()), logger.Logger.Repository);
            }
            {
                // Arrange
                // log4net.config.xml
                var obj = new DummyClass();
                // Act
                var logger = Log4netExtension.GetLogger(obj, typeof(DummyClass2));
                // Assert
                Assert.Equal(typeof(DummyClass2).FullName, logger.Logger.Name);
                Assert.Equal(LogManager.GetRepository(Assembly.GetEntryAssembly()), logger.Logger.Repository);
            }
        }

        [Fact()]
        public void GetLoggerTest_Logging()
        {
            // Arrange
            // log4net.config.xml
            var obj = new DummyClass();
            // Act
            var logger = Log4netExtension.GetLogger("hoge");
            // Assert
            logger.Debug("デバッグ");
            logger.Info("インフォ");
            try
            {
                throw new Exception("任意のエラー");
            }
            catch (Exception ex)
            {
                GlobalContext.Properties["UserId"] = "12345";
                logger.Error("メッセージ", ex);
            }
        }
    }
}
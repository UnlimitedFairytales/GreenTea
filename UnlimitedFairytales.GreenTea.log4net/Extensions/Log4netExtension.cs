using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace UnlimitedFairytales.GreenTea.log4net.Extensions
{
    public static class Log4netExtension
    {
        static Log4netExtension()
        {
            loggerAssembly = Assembly.GetEntryAssembly();
            var loggerRepository = LogManager.GetRepository(loggerAssembly);
            var fileInfo = new FileInfo("log4net.config.xml");
            XmlConfigurator.Configure(loggerRepository, fileInfo);
        }

        private static Assembly loggerAssembly;

        public static ILog GetLogger(this object obj, string loggerName)
        {
            return LogManager.GetLogger(loggerAssembly, loggerName);
        }

        public static ILog GetLogger(this object obj, Type type = null)
        {
            if (type == null)
            {
                type = obj.GetType();
            }
            return LogManager.GetLogger(type);
        }
    }
}

using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace UnlimitedFairytales.GreenTea.log4net.Extensions
{
    /// <summary>
    /// .NET Core系統はAppDomainの追加をサポートしないため、Assembly.GetEntryAssembly()は実行を開始したexeであることが保証される。
    /// https://docs.microsoft.com/ja-jp/dotnet/core/porting/net-framework-tech-unavailable
    /// </summary>
    public static class Log4netExtension
    {
        static Log4netExtension()
        {
            entryPointAssembly = Assembly.GetEntryAssembly();
            var loggerRepository = LogManager.GetRepository(entryPointAssembly);
            var fileInfo = new FileInfo("log4net.config.xml");
            XmlConfigurator.Configure(loggerRepository, fileInfo);
        }

        private static Assembly entryPointAssembly;

        /// <summary>
        /// 設定ファイルは、実行を開始したexeと同じ場所にあるlog4net.config.xmlを読み取ります。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="loggerName"></param>
        /// <returns></returns>
        public static ILog GetLogger(this object obj, string loggerName)
        {
            return LogManager.GetLogger(entryPointAssembly, loggerName);
        }

        /// <summary>
        /// 設定ファイルは、実行を開始したexeと同じ場所にあるlog4net.config.xmlを読み取ります。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

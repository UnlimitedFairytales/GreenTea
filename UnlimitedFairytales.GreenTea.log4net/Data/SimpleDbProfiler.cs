using StackExchange.Profiling.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using UnlimitedFairytales.GreenTea.log4net.Extensions;

namespace UnlimitedFairytales.GreenTea.log4net.Data
{
    public class SimpleDbProfiler : IDbProfiler
    {
        public IParameterTextGetter ParameterTextGetter { get; private set; }
        private const string LOGGER_NAME = "SQL";
        private const int MAX_MS = 999999;
        private const int DIGIT = 6;
        private Stopwatch stopwatch;
        private IDbCommand dbCommand;

        public bool IsActive => true;

        public SimpleDbProfiler(IParameterTextGetter parameterTextGetter)
        {
            this.ParameterTextGetter = parameterTextGetter;
        }

        public void ExecuteFinish(IDbCommand profiledDbCommand, SqlExecuteType executeType, DbDataReader reader)
        {
            dbCommand = profiledDbCommand;
            if (executeType != SqlExecuteType.Reader)
            {
                stopwatch.Stop();
                long millisec = MAX_MS < stopwatch.ElapsedMilliseconds ? MAX_MS : stopwatch.ElapsedMilliseconds;
                if (0 < dbCommand.Parameters.Count && this.ParameterTextGetter != null)
                {
                    var parametersText = "";
                    foreach (var item in dbCommand.Parameters)
                    {
                        parametersText = this.ParameterTextGetter.GetParameterText(item) + ", ";
                    }
                    parametersText = parametersText.Substring(0, parametersText.Length - 2);
                    this.GetLogger(LOGGER_NAME).Debug($"Parameters : {parametersText}");
                }
                this.GetLogger(LOGGER_NAME).Debug($"[{millisec,DIGIT}ms] " + dbCommand.CommandText);
            }
        }

        public void ExecuteStart(IDbCommand profiledDbCommand, SqlExecuteType executeType)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public void OnError(IDbCommand profiledDbCommand, SqlExecuteType executeType, Exception exception)
        {
            stopwatch.Stop();
            this.GetLogger(LOGGER_NAME).Error(profiledDbCommand.CommandText);
        }

        public void ReaderFinish(IDataReader reader)
        {
            stopwatch.Stop();
            long millisec = MAX_MS < stopwatch.ElapsedMilliseconds ? MAX_MS : stopwatch.ElapsedMilliseconds;
            if (0 < dbCommand.Parameters.Count && this.ParameterTextGetter != null)
            {
                var parametersText = "";
                foreach (var item in dbCommand.Parameters)
                {
                    parametersText = this.ParameterTextGetter.GetParameterText(item) + ", ";
                }
                parametersText = parametersText.Substring(0, parametersText.Length - 2);
                this.GetLogger(LOGGER_NAME).Debug($"Parameters : {parametersText}");
            }
            this.GetLogger(LOGGER_NAME).Debug($" [{millisec,DIGIT}ms] " + dbCommand.CommandText);
        }
    }
}

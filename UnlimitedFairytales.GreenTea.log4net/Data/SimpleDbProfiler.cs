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
        private const string LOGGER_NAME = "SQL";
        private Stopwatch stopwatch;
        private string commandText;

        public bool IsActive => true;

        public void ExecuteFinish(IDbCommand profiledDbCommand, SqlExecuteType executeType, DbDataReader reader)
        {
            commandText = profiledDbCommand.CommandText;
            if (executeType != SqlExecuteType.Reader)
            {
                stopwatch.Stop();
                long millisec = 9999 < stopwatch.ElapsedMilliseconds ? 9999 : stopwatch.ElapsedMilliseconds;
                this.GetLogger(LOGGER_NAME).Debug($"[{millisec,4}ms] " + commandText);
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
            long millisec = 9999 < stopwatch.ElapsedMilliseconds ? 9999 : stopwatch.ElapsedMilliseconds;
            this.GetLogger(LOGGER_NAME).Debug($"[{millisec,4}ms] " + commandText);
        }
    }
}

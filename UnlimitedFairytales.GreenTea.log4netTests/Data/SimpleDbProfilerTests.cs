using StackExchange.Profiling.Data;
using System.Data.Common;
using System.Data.SQLite;
using UnlimitedFairytales.GreenTea.log4net.SQLite;
using Xunit;
using Xunit.Abstractions;

namespace UnlimitedFairytales.GreenTea.log4net.Data.Tests
{
    public class SimpleDbProfilerTests
    {
        static readonly string DB_FILE_PATH = @"DB\sqlite.db";

        static void DeleteAndCreateDB(string dbFilePath)
        {
            if (File.Exists(DB_FILE_PATH))
            {
                File.Delete(DB_FILE_PATH);
            }
            var dirPath = Path.GetDirectoryName(DB_FILE_PATH);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            SQLiteConnection.CreateFile(dbFilePath);
        }

        private ITestOutputHelper testOutputHelper;

        public SimpleDbProfilerTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestSimpleDbProfiler()
        {
            // Arrange
            DeleteAndCreateDB(DB_FILE_PATH);
            DbConnection conn = new SQLiteConnection();
            conn.ConnectionString = $@"Data Source={DB_FILE_PATH}";
            var miniProfiler = new SimpleDbProfiler(new SQLiteParameterTextGetter());
            conn = new ProfiledDbConnection(conn, miniProfiler);
            conn.Open();
            var cmd = conn.CreateCommand();
            if (Directory.Exists("../logs")) Directory.Delete("../logs", true);

            // Act
            var dateTime = DateTime.Now;
            cmd.CommandText = "create table accounts (id INTEGER NOT NULL, name TEXT, primary key(id))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into accounts VALUES(1, 'Alice')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into accounts VALUES(2, $name)";
            cmd.Parameters.Add(new SQLiteParameter("$name", "Bob"));
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from accounts where id=$id";
            cmd.Parameters.Add(new SQLiteParameter("$id", 2));
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var str = "id:" + reader.GetInt32(0).ToString() + Environment.NewLine
                        + "name:" + reader.GetString(1);
                    testOutputHelper.WriteLine(str);
                }
            }

            // Assert
            var logFilePath = $"../logs/{dateTime.ToString("yyyyMMdd")}.log";
            Assert.True(File.Exists(logFilePath));
        }
    }
}
using Xunit;
using UnlimitedFairytales.GreenTea.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlimitedFairytales.GreenTea.StringExtensions.Tests
{
    public class StringToDateTimeExtensionTests
    {
        [Fact()]
        public void LocalToLocalTest()
        {
            // Arrange
            var d1 = new DateTime(2018, 08, 31, 00, 00, 00, DateTimeKind.Local);
            var d2 = new DateTime(2018, 08, 31, 23, 59, 59, DateTimeKind.Local);
            var d3 = new DateTime(2018, 08, 31, 23, 59, 59, 123, DateTimeKind.Local);
            var d4 = new DateTime(2018, 08, 31, 23, 59, 59, DateTimeKind.Utc).ToLocalTime();
            // Act

            // Assert 1
            Assert.Equal(d1, "20180831".LocalToLocal());
            Assert.Equal(d2, "20180831235959".LocalToLocal());
            Assert.Throws<FormatException>(() => "2018083123595912".LocalToLocal());
            Assert.Equal(d3, "20180831235959123".LocalToLocal());
            // Assert 2
            Assert.Equal(d1, "2018-08-31".LocalToLocal());
            Assert.Equal(d2, "2018-08-31 23:59:59".LocalToLocal());
            Assert.Throws<FormatException>(() => "2018-08-31 23:59:59.12".LocalToLocal());
            Assert.Equal(d3, "2018-08-31 23:59:59.123".LocalToLocal());
            // Assert 3
            Assert.Equal(d1, "2018/08/31".LocalToLocal());
            Assert.Equal(d2, "2018/08/31 23:59:59".LocalToLocal());
            Assert.Throws<FormatException>(() => "2018/08/31 23:59:59.12".LocalToLocal());
            Assert.Equal(d3, "2018/08/31 23:59:59.123".LocalToLocal());
            // Assert 4 timeゾーンが与えられた場合はUTCとして処理する
            var result4 = "20180831T235959+1200".LocalToLocal().Value.AddHours(+12);
            Assert.Equal(d4, result4);
            // Assert 5 timeゾーンが与えられた場合はUTCとして処理する
            var result5 = "2018-08-31T23:59:59+12:00".LocalToLocal().Value.AddHours(+12);
            Assert.Equal(d4, result5);
        }

        [Fact()]
        public void UtcToLocalTest()
        {
            // Arrange
            var d1 = new DateTime(2018, 08, 31, 00, 00, 00, DateTimeKind.Utc).ToLocalTime();
            var d2 = new DateTime(2018, 08, 31, 23, 59, 59, DateTimeKind.Utc).ToLocalTime();
            var d3 = new DateTime(2018, 08, 31, 23, 59, 59, 123, DateTimeKind.Utc).ToLocalTime();
            var d4 = new DateTime(2018, 08, 31, 23, 59, 59, DateTimeKind.Utc).ToLocalTime();
            // Act

            // Assert 1
            Assert.Equal(d1, "20180831".UtcToLocal());
            Assert.Equal(d2, "20180831235959".UtcToLocal());
            Assert.Throws<FormatException>(() => "2018083123595912".UtcToLocal());
            Assert.Equal(d3, "20180831235959123".UtcToLocal());
            // Assert 2
            Assert.Equal(d1, "2018-08-31".UtcToLocal());
            Assert.Equal(d2, "2018-08-31 23:59:59".UtcToLocal());
            Assert.Throws<FormatException>(() => "2018-08-31 23:59:59.12".UtcToLocal());
            Assert.Equal(d3, "2018-08-31 23:59:59.123".UtcToLocal());
            // Assert 3
            Assert.Equal(d1, "2018/08/31".UtcToLocal());
            Assert.Equal(d2, "2018/08/31 23:59:59".UtcToLocal());
            Assert.Throws<FormatException>(() => "2018/08/31 23:59:59.12".UtcToLocal());
            Assert.Equal(d3, "2018/08/31 23:59:59.123".UtcToLocal());
            // Assert 4 timeゾーンが与えられた場合はUTCとして処理する
            Assert.Equal(d4, "20180831T235959+1200".UtcToLocal().Value.AddHours(+12));
            // Assert 5 timeゾーンが与えられた場合はUTCとして処理する
            Assert.Equal(d4, "2018-08-31T23:59:59+12:00".UtcToLocal().Value.AddHours(+12));

        }
    }
}
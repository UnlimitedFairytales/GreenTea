using Xunit;
using UnlimitedFairytales.GreenTea.CsvHelper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using CsvHelper;

namespace UnlimitedFairytales.GreenTea.CsvHelper.Extensions.Tests
{
    public class AccountCsvDto
    {
        [Name("ID")]
        public long? Id { get; set; }
        [Name("名前")]
        public string Name { get; set; }
        [Name("E-Mail")]
        public string EMail { get; set; }
        [Name("年齢")]
        public int Age { get; set; }
        [Name("1 備考"), NameIndex(0)]
        public string Note { get; set; }
        [Name("1 備考"), NameIndex(1)]
        public string Note2 { get; set; }
        [Name("1 備考"), NameIndex(2)]
        public string Note3 { get; set; }
    }

    public class CsvHelperExtensionTests
    {
        [Fact()]
        public void ReadCsvTest()
        {
            {
                // Arrange
                var path = "./sjis-csv-sample.csv";
                // Act
                var accounts = path.ReadCsv<AccountCsvDto>(CsvHelperExtension.SJIS_WIN).ToList();
                // Assert
                Assert.Equal(4, accounts.Count);
                Assert.Equal("Alice", accounts[0].Name);
                Assert.Equal("alice@foo.com", accounts[0].EMail);
                Assert.Equal(18, accounts[0].Age);
                Assert.Equal("note", accounts[0].Note);
                Assert.Equal("note2", accounts[0].Note2);
                Assert.Equal("note3", accounts[0].Note3);
            }
            {
                // Arrange
                var path = "./sjis-csv-badsample.csv";
                // Act
                try
                {
                    path.ReadCsv<AccountCsvDto>(CsvHelperExtension.SJIS_WIN).ToList();
                }
                catch (BadDataException ex)
                {
                    // Assert
                    Assert.Contains(@"4,Dave,""dave@qu""x.com"",20,""no,""te"",""note2"",""note3""", ex.Message);
                }
            }
        }
    }
}
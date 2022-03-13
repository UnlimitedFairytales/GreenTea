using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Xunit;

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
                var accounts = path.ReadCsv<AccountCsvDto>(CsvHelperExtension.SJIS_WIN);
                // Assert
                Assert.Equal(4, accounts.Count);

                int i = 0;
                Assert.Equal(1, accounts[i].Id);
                Assert.Equal("Alice", accounts[i].Name);
                Assert.Equal("alice@foo.com", accounts[i].EMail);
                Assert.Equal(18, accounts[i].Age);
                Assert.Equal("note", accounts[i].Note);
                Assert.Equal("note2", accounts[i].Note2);
                Assert.Equal("note3", accounts[i].Note3);

                i = 1;
                Assert.Equal(2, accounts[i].Id);
                Assert.Equal("Bob", accounts[i].Name);
                Assert.Equal("bob@bar.com", accounts[i].EMail);
                Assert.Equal(21, accounts[i].Age);
                Assert.Equal("note", accounts[i].Note);
                Assert.Equal("note2", accounts[i].Note2);
                Assert.Equal("note3", accounts[i].Note3);

                i = 2;
                Assert.Equal(3, accounts[i].Id);
                Assert.Equal("Carol", accounts[i].Name);
                Assert.Equal("carol@baz.com", accounts[i].EMail);
                Assert.Equal(19, accounts[i].Age);
                Assert.Equal("note", accounts[i].Note);
                Assert.Equal("note2\r\nnote2-2", accounts[i].Note2);
                Assert.Equal("note3", accounts[i].Note3);

                i = 3;
                Assert.Equal(4, accounts[i].Id);
                Assert.Equal("Dave", accounts[i].Name);
                Assert.Equal("dave@qux.com", accounts[i].EMail);
                Assert.Equal(20, accounts[i].Age);
                Assert.Equal("note", accounts[i].Note);
                Assert.Equal("note2", accounts[i].Note2);
                Assert.Equal("note3", accounts[i].Note3);
            }
            {
                // Arrange
                var path = "./sjis-csv-sample.csv"; // 同一名の列があると、dynamicは失敗する
                // Act
                // Assert
                Assert.Throws<ReaderException>(() =>
                {
                    var accounts = path.ReadCsv<dynamic>(CsvHelperExtension.SJIS_WIN);
                });
            }
            {
                // Arrange
                var path = "./sjis-csv-sample2.csv";
                // Act
                var accounts = path.ReadCsv<dynamic>(CsvHelperExtension.SJIS_WIN);
                // Assert
                Assert.Equal(4, accounts.Count);

                int i = 0;
                Assert.Equal("1", accounts[i].ID);
                Assert.Equal("Alice", accounts[i].名前);
                // Assert.Equal("alice@foo.com", accounts[i].E-Mail);
                Assert.Equal("18", accounts[i].年齢);
                // Assert.Equal("note", accounts[i].1 備考);
                // Assert.Equal("note2", accounts[i].2 備考);
                // Assert.Equal("note3", accounts[i].3 備考);
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
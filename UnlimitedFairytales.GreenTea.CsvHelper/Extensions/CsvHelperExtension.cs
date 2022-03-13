using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace UnlimitedFairytales.GreenTea.CsvHelper.Extensions
{
    public static class CsvHelperExtension
    {
        public static readonly Encoding SJIS_WIN;
        public static readonly Encoding EUC_JP_WIN;
        public static readonly Encoding ISO_2022_JP_WIN;
        public static readonly Encoding UTF8;

        static CsvHelperExtension()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            SJIS_WIN = Encoding.GetEncoding(932);
            EUC_JP_WIN = Encoding.GetEncoding(51932);
            ISO_2022_JP_WIN = Encoding.GetEncoding(50220);
            UTF8 = Encoding.GetEncoding(65001);
        }

        public static CsvConfiguration GetCsvConfiguration(Encoding enc, string delimiter = null, BadDataFound badDataFound = null)
        {
            // https://github.com/JoshClose/CsvHelper/blob/27.1.1/src/CsvHelper/Configuration/CsvConfiguration.cs
            var cultureInfo = CultureInfo.InvariantCulture;
            var config = new CsvConfiguration(cultureInfo)
            {
                // var 27.1.1
                //AllowComments = false,
                AllowComments = true,
                //BadDataFound = ConfigurationFunctions.BadDataFound,
                //BufferSize = 0x1000, // 4096
                //CacheFields = false,
                //Comment = '#',
                //CountBytes = false,
                //CultureInfo
                //Delimiter = cultureInfo.TextInfo.ListSeparator, // ","
                //DetectDelimiter = false,
                //DetectDelimiterValues = new[] { ",", ";", "|", "\t" },
                //DetectColumnCountChanges = false,
                //DynamicPropertySort = null,
                //Encoding = Encoding.UTF8,
                Encoding = enc,
                //Escape = '"',
                //ExceptionMessagesContainRawData = true,
                //GetConstructor = ConfigurationFunctions.GetConstructor,
                //GetDynamicPropertyName = ConfigurationFunctions.GetDynamicPropertyName,
                //HasHeaderRecord = true,
                //HeaderValidated = ConfigurationFunctions.HeaderValidated,
                //IgnoreBlankLines = true,
                //IgnoreReferences = false,
                //IncludePrivateMembers = false, // true
                //InjectionCharacters = new[] { '=', '@', '+', '-' },
                //InjectionEscapeCharacter = '\t',
                //IsNewLineSet
                //LeaveOpen = false,
                //LineBreakInQuotedFieldIsBadData = false,
                //MemberTypes = MemberTypes.Properties,
                //MissingFieldFound = ConfigurationFunctions.MissingFieldFound,
                //Mode = 0,
                //NewLine = "\r\n",
                //PrepareHeaderForMatch = ConfigurationFunctions.PrepareHeaderForMatch,
                //ProcessFieldBufferSize = 1024,
                //Quote = '"',
                //ReadingExceptionOccurred = ConfigurationFunctions.ReadingExceptionOccurred,
                //ReferenceHeaderPrefix = null,
                //SanitizeForInjection = false,
                //ShouldQuote = ConfigurationFunctions.ShouldQuote,
                //ShouldSkipRecord = ConfigurationFunctions.ShouldSkipRecord,
                //ShouldUseConstructorParameters = ConfigurationFunctions.ShouldUseConstructorParameters,
                //TrimOptions = 0,
                //UseNewObjectForNullReferenceMembers = true,
                //WhiteSpaceChars = new char[] { ' ' },
            };
            if (delimiter != null)
            {
                config.Delimiter = delimiter;
            }
            if (badDataFound != null)
            {
                config.BadDataFound = badDataFound;
            }
            return config;
        }

        public static List<T> ReadCsv<T>(this string filePath, Encoding enc, string delimiter = null)
        {
            var config = CsvHelperExtension.GetCsvConfiguration(enc, delimiter);
            return CsvHelperExtension.ReadCsv<T>(filePath, config);
        }
        
        public static List<T> ReadCsv<T>(this string filePath, CsvConfiguration config)
        {
            using (var sr = new StreamReader(filePath, config.Encoding))
            using (var reader = new CsvReader(sr, config))
            {
                return reader.GetRecords<T>().ToList();
            }
        }
    }
}

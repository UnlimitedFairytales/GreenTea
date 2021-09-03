using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlimitedFairytales.GreenTea.CsvHelper.Extensions
{
    public static class CsvHelperExtension
    {
        public static readonly Encoding SJIS_WIN;
        public static readonly Encoding EUC_JP;
        public static readonly Encoding ISO_2022_JP;
        public static readonly Encoding UTF8;

        static CsvHelperExtension()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            SJIS_WIN = Encoding.GetEncoding(932);
            EUC_JP = Encoding.GetEncoding(51932);
            ISO_2022_JP = Encoding.GetEncoding(50220);
            UTF8 = Encoding.GetEncoding(65001);
        }

        public static CsvConfiguration GetCsvConfiguration(Encoding enc, BadDataFound badDataFound = null)
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
            if (badDataFound != null)
            {
                config.BadDataFound = badDataFound;
            }
            return config;
        }

        public static List<T> ReadCsv<T>(this string filePath, Encoding enc, CsvConfiguration config = null)
        {
            if (config == null)
            {
                config = CsvHelperExtension.GetCsvConfiguration(enc);
            }
            using (var sr = new StreamReader(filePath, config.Encoding))
            using (var reader = new CsvReader(sr, config))
            {
                return reader.GetRecords<T>().ToList();
            }
        }
    }
}

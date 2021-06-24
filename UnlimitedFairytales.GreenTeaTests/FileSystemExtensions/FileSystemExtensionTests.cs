using System.IO;
using Xunit;

namespace UnlimitedFairytales.GreenTea.FileSystemExtensions.Tests
{
    public class FileSystemExtensionTests
    {
        [Fact()]
        public void GetOpenWritableStreamOrNullTest_ReturnStream()
        {
            // Assert
            var testDirPath = $@".\TEST\{nameof(GetOpenWritableStreamOrNullTest_ReturnStream)}";
            var testFilePath = Path.Combine(testDirPath, "text.txt");
            Directory.CreateDirectory(testDirPath);
            File.WriteAllText(testFilePath, testFilePath);

            // Act
            using (var stream = testFilePath.GetOpenWritableStreamOrNull())
            {
                // Assert
                Assert.NotNull(stream);
            }
        }

        [Fact()]
        public void GetOpenWritableStreamOrNullTest_ReturnNull()
        {
            // Assert
            var testDirPath = $@".\TEST\{nameof(GetOpenWritableStreamOrNullTest_ReturnNull)}";
            var testFilePath = Path.Combine(testDirPath, "text.txt");
            Directory.CreateDirectory(testDirPath);
            File.WriteAllText(testFilePath, testFilePath);

            // Act
            using (var stream0 = new FileStream(testFilePath, FileMode.Open, FileAccess.ReadWrite))
            using (var stream = testFilePath.GetOpenWritableStreamOrNull())
            {
                // Assert
                Assert.Null(stream);
            }
        }
    }
}
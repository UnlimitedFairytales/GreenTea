using Xunit;

namespace UnlimitedFairytales.GreenTea.FileSystemExtensions.Tests
{
    public class FileSystemExtensionTests
    {
        [Fact()]
        public void GetOpenWritableStreamOrNullTest_ReturnStream()
        {
            // Arrange
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
            // Arrange
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

        [Fact()]
        public void CreateOrClearDirectoryTest()
        {
            static void Arrange(string rootDir, out string subDir, out string subSubDir, out string f1, out string f2, out string f3)
            {
                subDir = rootDir + "/Sub";
                subSubDir = subDir + "/SubSub";
                f1 = rootDir + "/f1.txt";
                f2 = subDir + "/f2.txt";
                f3 = subSubDir + "/f3.txt";
                if (!Directory.Exists(rootDir)) Directory.CreateDirectory(rootDir);
                if (!Directory.Exists(subDir)) Directory.CreateDirectory(subDir);
                if (!Directory.Exists(subSubDir)) Directory.CreateDirectory(subSubDir);
                File.WriteAllText(f1, f1);
                File.WriteAllText(f2, f2);
                File.WriteAllText(f3, f3);

                Assert.True(Directory.Exists(rootDir));
                Assert.True(Directory.Exists(subDir));
                Assert.True(Directory.Exists(subSubDir));
                Assert.True(File.Exists(f1));
                Assert.True(File.Exists(f2));
                Assert.True(File.Exists(f3));
            }

            {
                // Arrange
                string rootDir = "./Root1";
                string subDir, subSubDir, f1, f2, f3;
                Arrange(rootDir, out subDir, out subSubDir, out f1, out f2, out f3);

                // Act
                rootDir.CreateOrClearDirectory(true);

                // Assert
                Assert.True(Directory.Exists(rootDir));
                Assert.False(Directory.Exists(subDir));
                Assert.False(Directory.Exists(subSubDir));
                Assert.False(File.Exists(f1));
                Assert.False(File.Exists(f2));
                Assert.False(File.Exists(f3));
            }

            {
                // Arrange
                string rootDir = "./Root2";
                string subDir, subSubDir, f1, f2, f3;
                Arrange(rootDir, out subDir, out subSubDir, out f1, out f2, out f3);

                // Act
                rootDir.CreateOrClearDirectory(false);

                // Assert
                Assert.True(Directory.Exists(rootDir));
                Assert.True(Directory.Exists(subDir));
                Assert.True(Directory.Exists(subSubDir));
                Assert.True(File.Exists(f1));
                Assert.True(File.Exists(f2));
                Assert.True(File.Exists(f3));
            }

            {
                // Arrange
                string rootDir = "./Root3";
                if (Directory.Exists(rootDir))
                {
                    Directory.Delete(rootDir);
                }

                // Act
                rootDir.CreateOrClearDirectory(true);

                // Assert
                Assert.True(Directory.Exists(rootDir));
            }
        }
    }
}
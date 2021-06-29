using System;
using System.IO;
using UnlimitedFairytales.GreenTea.WindowsTests;
using Xunit;

namespace UnlimitedFairytales.GreenTea.Windows.FileSystemExtensions.Tests
{
    public class FileSystemExtensionTests
    {
        [WindowsFact]
        public void GetOwnerTest()
        {
            // Arrange
            var testDirPath = $@".\TEST\{nameof(GetOwnerTest)}";
            var testFilePath = Path.Combine(testDirPath, "text.txt");
            Directory.CreateDirectory(testDirPath);
            File.WriteAllText(testFilePath, testFilePath);
            var principal = @$"{Environment.UserDomainName}\{Environment.UserName}";

            // Act
            var owner = testFilePath.GetOwner();

            // Assert
            Assert.Equal(principal, owner);
        }
    }
}
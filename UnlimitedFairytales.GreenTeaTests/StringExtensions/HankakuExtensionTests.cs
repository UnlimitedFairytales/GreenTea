using Xunit;

namespace UnlimitedFairytales.GreenTea.StringExtensions.Tests
{
    public class HankakuExtensionTests
    {
        [Fact()]
        public void IsHankakuOnlyTest()
        {
            {
                // Arrange
                var str = @"
 !""#$%&'()*+,-./0123456789:;<=>?
@ABCDEFGHIJKLMNOPQRSTUVWXWZ[\]^_
`abcdefghijklmnopqrstuvwxwz{|}~ ";

                // Act
                var result = str.IsHankakuOnly();
                // Assert
                Assert.True(result);
            }
            {
                // Arrange
                var str = @"
 !""#$%&'()*+,-./0123456789:;<=>?
@ABCDEFGHIJKLMNOPQRSTUVWXWZ[\]^_
`abcdefghijklmnopqrstuvwxwz{|}~ 
あ";

                // Act
                var result = str.IsHankakuOnly();
                // Assert
                Assert.False(result);
            }
        }
    }
}
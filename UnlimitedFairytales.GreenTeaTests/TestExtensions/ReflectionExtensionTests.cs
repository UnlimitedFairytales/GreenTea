using Xunit;

namespace UnlimitedFairytales.GreenTea.TestExtensions.Tests
{
    public class ReflectionExtensionTests
    {
        public readonly string ReadonlyFieldSample = "foo";

        [Fact()]
        public void ReflectionSetFieldTest()
        {
            // Arrange
            var obj = new ReflectionExtensionTests();

            // Act
            obj.ReflectionSetField(nameof(obj.ReadonlyFieldSample), "bar");

            // Assert
            Assert.Equal("bar", obj.ReadonlyFieldSample);
        }
    }
}
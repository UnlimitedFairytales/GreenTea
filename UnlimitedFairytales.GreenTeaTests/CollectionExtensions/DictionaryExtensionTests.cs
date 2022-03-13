using Xunit;

namespace UnlimitedFairytales.GreenTea.CollectionExtensions.Tests
{
    public class DictionaryExtensionTests
    {
        [Fact()]
        public void AddOrUpdateTest()
        {
            {
                // Arrange
                var dic = new Dictionary<string, string>()
                {
                    ["foo"] = "Alice",
                    ["bar"] = "Bob",
                    ["baz"] = "Carol",
                    ["qux"] = "Dave"
                };
                // Act
                dic.AddOrUpdate("foo", "Eve");
                // Assert
                Assert.Equal("Eve", dic["foo"]);
            }
            {
                // Arrange
                var dic = new Dictionary<string, string>()
                {
                    ["foo"] = "Alice",
                    ["bar"] = "Bob",
                    ["baz"] = "Carol",
                    ["qux"] = "Dave"
                };
                // Act
                dic.AddOrUpdate("foobar", "Eve");
                // Assert
                Assert.Equal("Eve", dic["foobar"]);
            }
        }
    }
}
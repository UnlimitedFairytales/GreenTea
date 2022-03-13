using Xunit;

namespace UnlimitedFairytales.GreenTea.ObjectExtensions.Tests
{
    public class CloneExtensionTests
    {
        class SerializableClass
        {
            public string Foo;
            public string Bar;
            public List<SerializableClass2> Baz;
        }

        class SerializableClass2
        {
            public int Hoge;
            public string Fuga;
        }

        [Fact()]
        public void CloneTest()
        {
            // Arrange
            var obj = new SerializableClass() {
                Foo = "apple",
                Bar = "banana",
                Baz = new List<SerializableClass2>() {
                    new SerializableClass2() { Hoge = 1, Fuga = "123" },
                    new SerializableClass2() { Hoge = 2, Fuga = "456" }
                }
            };
            // Act
            var cloned = obj.Clone();
            // Assert
            Assert.NotSame(obj, cloned);
            Assert.Equal(obj.Foo, cloned.Foo);
            Assert.Equal(obj.Bar, cloned.Bar);
            Assert.NotSame(obj.Baz, cloned.Baz);
            for (int i = 0; i < obj.Baz.Count; i++)
            {
                Assert.NotSame(obj.Baz[i], cloned.Baz[i]);
                Assert.Equal(obj.Baz[i].Hoge, cloned.Baz[i].Hoge);
                Assert.Equal(obj.Baz[i].Fuga, cloned.Baz[i].Fuga);
            }
        }
    }
}
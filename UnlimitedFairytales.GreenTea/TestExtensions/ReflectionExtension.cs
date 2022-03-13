namespace UnlimitedFairytales.GreenTea.TestExtensions
{
    public static class ReflectionExtension
    {
        public static void ReflectionSetField(this object obj, string fieldName, object value)
        {
            var info = obj.GetType().GetField(fieldName);
            info.SetValue(obj, value);
        }
    }
}

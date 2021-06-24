using System.Text.Json;

namespace UnlimitedFairytales.GreenTea.ObjectExtensions
{
    public static class CloneExtension
    {
        public static T Clone<T>(this T cloneSource)
        {
            var option = new JsonSerializerOptions();
            option.IncludeFields = true;
            string jsonString = JsonSerializer.Serialize<T>(cloneSource, option);
            var cloned = JsonSerializer.Deserialize<T>(jsonString, option);
            return cloned;
        }
    }
}

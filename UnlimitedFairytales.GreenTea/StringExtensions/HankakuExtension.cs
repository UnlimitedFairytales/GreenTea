using System.Text;

namespace UnlimitedFairytales.GreenTea.StringExtensions
{
    public static class HankakuExtension
    {
        static readonly Encoding encUtf8 = Encoding.UTF8;

        public static bool IsHankakuOnly(this string text)
        {
            int num = encUtf8.GetByteCount(text);
            return num == text.Length;
        }
    }
}

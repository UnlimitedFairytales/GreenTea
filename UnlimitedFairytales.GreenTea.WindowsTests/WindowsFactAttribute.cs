using System.Runtime.InteropServices;
using Xunit;

namespace UnlimitedFairytales.GreenTea.WindowsTests
{
    class WindowsFactAttribute : FactAttribute
    {
        public WindowsFactAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Skip = "Windows only";
            }
        }
    }
}

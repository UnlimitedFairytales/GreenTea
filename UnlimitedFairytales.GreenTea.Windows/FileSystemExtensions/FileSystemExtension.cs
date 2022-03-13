namespace UnlimitedFairytales.GreenTea.Windows.FileSystemExtensions
{
    public static class FileSystemExtension
    {
        public static string GetOwner(this string filePath)
        {
#pragma warning disable CA1416 // プラットフォームの互換性を検証
            // Windowsのみで使用可能
            var info = new FileInfo(filePath);
            var security = info.GetAccessControl();
            var ntAccount = security.GetOwner(typeof(System.Security.Principal.NTAccount));
            return ntAccount.Value;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        }
    }
}

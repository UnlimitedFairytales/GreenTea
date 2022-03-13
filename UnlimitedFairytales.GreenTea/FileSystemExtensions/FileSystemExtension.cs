namespace UnlimitedFairytales.GreenTea.FileSystemExtensions
{
    public static class FileSystemExtension
    {
        /// <summary>
        /// 開けない場合（書き込みロックされている場合）nullを返す。
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static FileStream GetOpenWritableStreamOrNull(this string filePath)
        {
            try
            {
                return new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (Exception)
            {
            }
            return null;
        }

        public static void CreateOrClearDirectory(this string dirPath, bool clears = false)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            if (clears)
            {
                var filePaths = Directory.GetFiles(dirPath);
                foreach (var item in filePaths)
                {
                    File.Delete(item);
                }
                var dirPaths = Directory.GetDirectories(dirPath);
                foreach (var item in dirPaths)
                {
                    FileSystemExtension.CreateOrClearDirectory(item, clears);
                    Directory.Delete(item);
                }
            }
        }
    }
}

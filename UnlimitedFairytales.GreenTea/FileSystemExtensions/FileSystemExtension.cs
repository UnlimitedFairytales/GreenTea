using System;
using System.IO;

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
    }
}

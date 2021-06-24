using System.Collections.Generic;

namespace UnlimitedFairytales.GreenTea.CollectionExtensions
{
    public static class DictionaryExtension
    {
        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }
    }
}

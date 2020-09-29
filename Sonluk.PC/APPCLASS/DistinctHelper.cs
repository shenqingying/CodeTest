using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.APPCLASS
{
    public static class DistinctHelper
    {
        /// <summary>
        /// 扩展IEnumerable，根据自定义key值返回去重内容
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source">数据源</param>
        /// <param name="keySelector">key值</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
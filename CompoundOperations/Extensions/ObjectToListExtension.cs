using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace CompoundOperations.Extensions
{
    public static class ObjectToListExtension
    {
        /// <summary>
        /// 将对象转换成字符串集合
        /// </summary>
        /// <param name="obj">数据源</param>
        /// <returns></returns>
        public static IEnumerable<string> ToStringList(this object obj)
        {
            List<string> result = new List<string>();
            if (obj == null)
            {
                return result;
            }

            Type type = obj.GetType();
            if (type == typeof(string)
                || type == typeof(char)
                || type == typeof(decimal)
                || type == typeof(DateTime))
            {
                result.Add(obj.ToString());
                return result;
            }
            
            IEnumerable source = obj as IEnumerable;
            if (source != null)
            {
                foreach (var item in source)
                {
                    result.Add(item.ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// 将对象转换成去重的字符串集合
        /// </summary>
        /// <param name="obj">数据源</param>
        /// <returns></returns>
        public static IEnumerable<string> ToDistinctStringList(this object obj)
        {
            IEnumerable<string> list = ToStringList(obj);
            return list.Distinct();
        }
    }
}

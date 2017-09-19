using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

namespace Common
{
    public static class ExtendFunc
    {
        /// <summary>
        /// obj的扩展方法，允许对象转换成json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        /// <summary>
        /// 为python准备，T为自定义引用类型，建议重写ToString
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string toListString<T>(this T[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (typeof(ValueType).IsAssignableFrom(typeof(T))) //如果T是值类型
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sb.Append(array[i] + ",");
                }
            }
            else //引用类型 如果是自定义的引用类型建议重写ToString
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sb.AppendFormat("{0},", array[i].ToString());
                }
            }
            sb.Append("]");
            return sb.ToString().Replace(",]", "]");
        }

        

        /// <summary>
        /// 将json字符串转为字典
        /// </summary>
        /// <param name="str">json字符串，并非所有的字符串</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">参数异常，转换失败，返回null</exception>
        /// <exception cref="ArgumentNullException">参数为空，返回null</exception>
        /// <exception cref="InvalidOperationException">当方法调用对于对象的当前状态无效时引发的异常,返回null</exception>
        public static Dictionary<string, object> JsonToDict(this string str)
        {
            try
            {
                var js = new JavaScriptSerializer();
                return (Dictionary<string, object>)js.DeserializeObject(str);
            }
            catch
            {
                return null;
            }
        }

    }
}
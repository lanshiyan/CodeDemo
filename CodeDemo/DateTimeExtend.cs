using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemo
{
    //DateTime类型的扩展方法
    //扩展方法写法: 静态类中定义静态方法，方法的第一个参数是要扩展的类型，需要使用关键字this
    public static class DateTimeExtend
    {
        #region 扩展方法
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToCommonString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion


    }

    public class DateTimeDemo : IDemo
    {
        public void DemoTest()
        {
            //Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //Console.WriteLine(DateTime.Now.ToString());
            //Console.WriteLine(DateTime.Now.AddDays(1).ToString("yyyyMMddHHmmss")); 
            //Console.WriteLine(DateTime.Now.ToLongDateString());//yyyy年MM月dd日
            //Console.WriteLine(DateTime.Now.ToShortDateString());//yyyy/MM/dd
            //Console.WriteLine(DateTime.Now.ToLongTimeString());//HH:mm:ss
            //Console.WriteLine(DateTime.Now.ToShortTimeString());//HH:mm
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

    }

}

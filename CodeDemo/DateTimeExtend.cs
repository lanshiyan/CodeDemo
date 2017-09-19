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

        /// <summary>
        /// 将日期转为时间戳(秒级)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int ToTimeStampS(this DateTime dt)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            return (int)(dt - start).TotalSeconds;
        }

        /// <summary>
        /// 将日期转为时间戳(毫秒级)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToTimeStampMS(this DateTime dt)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long) (dt - start).TotalMilliseconds;
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

            //Console.WriteLine(addMonth(DateTime.Now, 1).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 2).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 3).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 4).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 5).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 6).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 7).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 8).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 9).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 10).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 11).ToCommonString());
            //Console.WriteLine(addMonth(DateTime.Now, 12).ToCommonString());
        }

        #region 手动实现月份增加
        public DateTime addMonth(DateTime dt, int ms)
        {
            int month = dt.Month + ms - 1;
            int year = dt.Year + month / 12;
            month = month % 12 + 1;
            return new DateTime(year, month, 1);
        } 
        #endregion

    }

}

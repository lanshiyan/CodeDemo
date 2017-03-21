using System;
using System.Dynamic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Xml;

namespace CodeDemo
{
    public class StringDemo : IDemo
    {
        public void DemoTest()
        {
            //double b = 1.23232423423;
            //Console.WriteLine(b.ToString("N5"));//1.23232

            //Console.WriteLine(""==null);//false

            // Console.WriteLine(Convert.ToDouble(".")); //异常，输入的字符串格式异常

            #region 去掉字符串尾部的指定位置的字符

            //string teststr = "a,d,c,e,f,h，,";
            //Console.WriteLine(teststr.TrimEnd(','));//去掉最后一个，
            //Console.WriteLine(teststr.Remove(teststr.IndexOf("f", StringComparison.CurrentCultureIgnoreCase), 1));//去掉f，remove方法中截取位置包含起始位置   //a,d,c,e,,h，,
            //Console.WriteLine(teststr.TrimEnd(new char[] { ',', '，' }));//推测从后向前 只要满足数组中字符即去掉 //a,d,c,e,f,h

            #endregion

            #region max min

            //Console.WriteLine("----------------int--------------------");
            //Console.WriteLine(int.MaxValue);
            //Console.WriteLine(int.MinValue);
            //Console.WriteLine("----------------short--------------------");
            //Console.WriteLine(short.MaxValue);
            //Console.WriteLine(short.MinValue);
            //Console.WriteLine("----------------long--------------------");
            //Console.WriteLine(long.MaxValue);
            //Console.WriteLine(long.MinValue);
            //Console.WriteLine("----------------double--------------------");
            //Console.WriteLine(double.MaxValue);
            //Console.WriteLine(double.MinValue);
            //Console.WriteLine("----------------float--------------------");
            //Console.WriteLine(float.MaxValue);
            //Console.WriteLine(float.MinValue);

            #endregion

            #region 字符串分割

            //string str = string.Format("SELECT top 5 URLID,title,digest FROM TEXTDATAVIEW WHERE {0} order by date", 123456);
            //Console.WriteLine(str.Substring(str.IndexOf("WHERE", StringComparison.OrdinalIgnoreCase) + 5));
            //indexof 找到的是目标字符串首字符出现的位置 截取字符串时应考虑目标字符串的长度

            //string strtest = "";
            //string[] temp = strtest.Split(new[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
            ////分割字符串之前必须要做空处理，否则返回值是长度为0的数组
            ////if (temp!=null)//string.Split()返回的数据组是不需要进行空判断的
            ////{

            ////}
            //foreach (var s in temp)
            //{
            //    Console.WriteLine(s);
            //}

            #endregion

            #region 运行路径拼接

            //string basepath = AppDomain.CurrentDomain.BaseDirectory;
            //Console.WriteLine(basepath);// E:\\\\
            //string path = "./log/";
            //Console.WriteLine(string.Concat(basepath, path)); //e:\sda\./log/  string.Concat()直接拼接 

            //path = Path.Combine(basepath, path);
            //if (Directory.Exists(path))
            //{
            //    Console.WriteLine(true);
            //}
            //Console.WriteLine(path);

            #endregion

            #region Encoding

            //bodyname 是简单的编码名称  encodingname 是易懂的名称
            // Encoding encoding = Encoding.GetEncoding("gb2312");
            //Console.WriteLine(encoding.BodyName);//gb2312
            //Console.WriteLine(encoding.EncodingName);//简体中文(GB2312)
            //Encoding encoding = Encoding.GetEncoding("gbk");
            //Console.WriteLine(encoding.BodyName);//gb2312
            //Console.WriteLine(encoding.EncodingName);//简体中文(GB2312)
            //Encoding encoding = Encoding.GetEncoding("utf-8");
            //Console.WriteLine(encoding.EncodingName);//Unicode (UTF-8)

            #endregion

            #region foreach parallel 顺序测试

            //foreach  顺序执行
            //Parallel.ForEach  并行执行，只有数据量较小的偶发情况下顺序执行，所以绝对不能当做顺序执行
            //在强调运行顺序的代码中千万不要使用并行计算，并行计算是不能保证按照数组、集合的先后顺序执行

            //string[] teststrs = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };

            //foreach (var s in teststrs)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("********************************************");
            //Parallel.ForEach(teststrs, s => Console.WriteLine(s));

            #endregion

            #region 参数命名和默认值

            //Write(s: "2244", i: 12);//使用参数命名不必按照顺序输入参数  默认参数可以不写

            #endregion

            #region MD5
            //Console.WriteLine(GetMd5("123456"));
            //Console.WriteLine(GetMd5Lower("123456"));
            //Console.WriteLine(GetMd5Upper("123456"));
            //Console.WriteLine(Md5Encry32Bit("123456"));
            #endregion

            #region Xml操作

            //XmlDocument xmldoc = new XmlDocument();
            //string s = CreatedXml();
            //xmldoc.LoadXml(s.Substring(s.IndexOf("<PAY>")));
            //XmlNode root = xmldoc.ChildNodes[0];
            //XmlNode root2 = xmldoc.SelectSingleNode("PAY");
            //Console.WriteLine(root == root2);
            //root2 = xmldoc.SelectSingleNode("/PAY/BODY/ZO");
            //Console.WriteLine(root2.InnerText);
            //Console.WriteLine(root.ChildNodes[0].ChildNodes[2].InnerText);

            #endregion

            #region byte数组
            //string temp = "12345678990";
            //byte[] bts = Encoding.UTF8.GetBytes(temp);
            //foreach (var bt in bts)
            //{
            //    Console.WriteLine(bt);//返回ASCII值
            //}
            //Console.WriteLine($"byte数组长度是：{bts.Length}");
            //Console.WriteLine(Encoding.UTF8.GetString(bts));
            #endregion

            #region 邮件测试

            //EmailHelper email=new EmailHelper("smtp.163.com", "1304679383@qq.com", "lanshiyan815@163.com", "08155180", "测试", "这是一封测试邮件：http://www.baidu.com", true, false);
            //email.SendWithoutAttachments();

            #endregion

            #region 边界类

            //dynamic temp = new ExpandoObject();
            //temp.tag = "测试";
            //temp.age = 12;
            //BorderClass(temp);

            #endregion


        }

        #region 测试方法

        #region 参数命名和默认值
        //第一个带默认值的参数，其后的参数都必须有默认值
        public void Write(int i, string s, bool b = false)
        {
            Console.WriteLine($"i:{i};s:{s},b:{b}"); //等价于string.Format("{0}{1}{2}", 1, 2, 2);

        }

        #endregion

        #region MD5
        /// <summary>
        /// 32位大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMd5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var temp = md5.ComputeHash(Encoding.Default.GetBytes(str));
            return BitConverter.ToString(temp).Replace("-", "");
        }
        /// <summary>
        /// 32位小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMd5Lower(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var temp = md5.ComputeHash(Encoding.Default.GetBytes(str));
            string res = "";
            for (int i = 0; i < temp.Length; i++)
            {
                res += temp[i].ToString("x2");
            }
            return res;
        }
        /// <summary>
        /// 32位大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMd5Upper(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var temp = md5.ComputeHash(Encoding.Default.GetBytes(str));
            string res = "";
            for (int i = 0; i < temp.Length; i++)
            {
                res += temp[i].ToString("X2");
            }
            return res;
        }

        /// <summary>
        /// 32位大写 方法已过期，不建议使用
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [Obsolete]
        public static string Md5Encry32Bit(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        #endregion

        #region XML操作

        public static string CreatedXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.Append("<PAY>");
            sb.Append("<BODY>");
            sb.AppendFormat("<SID>{0}</SID>", 12);
            sb.AppendFormat("<SO>{0}</SO>", 23);
            sb.AppendFormat("<SA>{0}</SA>", 34);
            sb.AppendFormat("<ZO>{0}</ZO>", 45);
            sb.AppendFormat("<VER>{0}</VER>", 56);
            sb.AppendFormat("<OP>{0}</OP>", 67);//查询订单
            sb.AppendFormat("<SIGN>{0}</SIGN>", 78);
            sb.AppendFormat("<CC>{0}</CC>", 89);
            sb.Append("</BODY>");
            sb.Append("</PAY>");
            return sb.ToString();
        }

        #endregion

        #region 边界类

        //不知道理解的是否正确，在参数太多的情况下，定义一个参数“集合”（各个参数的类型不一致），将集合的内容暴露给外部，在调用此方法的时候，根据“集合”内容传入参数。这样的参数集合构成的边界类并没有实际的实体意义，只是可以帮助开发人员识别需求
        public void BorderClass(dynamic expando)
        {
            Console.WriteLine($"tag:{expando.tag};age:{expando.age}");
        }
        #endregion

        #endregion


    }
}
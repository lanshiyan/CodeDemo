using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Xml;
using Common;

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

            #region 边界类 动态 及匿名类

            //dynamic temp = new ExpandoObject();
            //temp.tag = "测试";
            //temp.age = 12;
            //BorderClass(temp);

            //动态可以与匿名类结合
            //集合的声明中不能出现匿名类，但是可以使用动态来代替匿名类  
            //然后在向集合中添加对象时使用匿名 
            //避免重新声明类  针对只使用一次的对象

            //List<dynamic> list = new List<dynamic>();
            //list.Add(new { Name = "1" });
            //list.Add(new { Name = "2" });
            //foreach (dynamic o in list)
            //{
            //    Console.WriteLine(o.Name);
            //}

            #endregion

            #region 二进制运算 与& 或| 非！

            //真值表
            //Console.WriteLine(true & true);
            //Console.WriteLine(true & false);
            //Console.WriteLine(false & false);
            //Console.WriteLine(true | true);
            //Console.WriteLine(true | false);
            //Console.WriteLine(false | false);

            #endregion

            #region GroupBy and OrderBy

            //IList<Test> list = new List<Test>()
            //{
            //        new Test() {Age = 18, Id =  1, Name = "152"},
            //        new Test() {Age = 17, Id = 6, Name = "273"},
            //        new Test() {Age = 19, Id = 2, Name = "453"},
            //        new Test() {Age = 19, Id = 4, Name = "812"},
            //        new Test() {Age = 18, Id = 3, Name = "213"},
            //        new Test() {Age = 19, Id = 5, Name = "645"},
            //        new Test() {Age = 17, Id = 7, Name = "789"}
            //};

            //var res = list.GroupBy(t => t.Age).OrderBy(t => t.Key);//返回的是IOrderedEnumerable<TSource> ,这是先分组再排序
            ////var res1 = list.OrderBy(t => t.Age).GroupBy(t => t.Age);//返回的是IEnumerable<IGrouping<TKey, TSource>>，这是先排序再分组
            //foreach (var group in res)
            //{
            //    foreach (Test test in group)
            //    {
            //        Console.WriteLine($"{group.Key}:age={test.Age},name={test.Name}");
            //    }
            //}

            #endregion

            #region 匿名类 输出 python 字典列表[{},{}]  
            //var list=new List<string>();
            //list.Add(new {at=DateTime.Now.ToTimeStampS(),value=55}.ToJson());
            //list.Add(new { at = DateTime.Now.AddMinutes(20).ToTimeStampS(), value = 56 }.ToJson());
            //list.Add(new { at = DateTime.Now.AddTicks(50).ToTimeStampS(), value = 58 }.ToJson());

            //Console.WriteLine(list.ToArray().toListString()); 
            #endregion

            #region 字典转json

            //Dictionary<string,string> dict=new Dictionary<string, string>();
            //dict.Add("01",new {name="4545",age=18}.ToJson());
            //Console.WriteLine(dict.ToJson());
            ////{"01":{"name":"4545","age":"18"}}


            #endregion

            #region string 引用
            ////string是引用类型，但是在编译器中当做值类型来使用
            ////想要使用引用的功能需要使用ref 
            ////字符串是一个不可变对象，赋值的本质是将开辟内存指向新地址
            //string s1 = "hellow", s2 = "world";
            //Console.WriteLine($"before change :{s1}----{s2}");
            //Change(s1, s2);
            //Console.WriteLine($"after change :{s1}----{s2}");

            //Console.WriteLine($"before change :{s1}----{s2}");
            //Change(ref s1, ref s2);
            //Console.WriteLine($"after change :{s1}----{s2}");

            //string str1 = "123", str2 = "123";
            //Console.WriteLine(object.ReferenceEquals(str1,str2));//true ，两个不同字符串对象内容相同。相同字符串是指向同一块内存的（即字符串在拘留池的位置是一样的）
            //str2 = "456";//str2再次赋值不会影响str1
            //Console.WriteLine(str1);//123

            #endregion

            #region 递归锁 有存疑
            //同一个线程可以多次获取同一个递归锁，不会产生死锁。而如果一个线程多次获取同一个非递归锁，则会产生死锁。
            //int i = 11;
            //Console.WriteLine(11);
            //LockTest(i);

            #endregion

           
                
        }

        #region 测试方法

        #region 递归锁

        public void LockTest(int i)
        {
            lock (this)
            {
                if (i>10)
                {
                    i--;
                    Console.WriteLine(i);
                    LockTest(i);
                }
            }
        }


        #endregion

        #region string 引用

        public void Change(ref string s1, ref string s2)
        {
            s1 = s2;
            s2 = s1 + s2;
        }

        public void Change(string s1, string s2)
        {
            s1 = s2;
            s2 = s1 + s2;
        }
        #endregion

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
        //边界类描述外部参与者与系统之间的交互。例如表单、对话框、菜单、接口。

        //不知道理解的是否正确，在参数太多的情况下，定义一个参数“集合”（各个参数的类型不一致），将集合的内容暴露给外部，在调用此方法的时候，根据“集合”内容传入参数。这样的参数集合构成的边界类并没有实际的实体意义，只是可以帮助开发人员识别需求
        public void BorderClass(dynamic expando)
        {
            Console.WriteLine($"tag:{expando.tag};age:{expando.age}");
        }

        #endregion

        #endregion


    }
}
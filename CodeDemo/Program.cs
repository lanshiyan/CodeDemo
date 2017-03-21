#define bugger
//#define release
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {

#if release
            Console.WriteLine("请输入类型：StringDemo|DateTimeDemo|RegexDemo");
            string key = Console.ReadLine();
            while (string.IsNullOrEmpty(key) || !Regex.IsMatch(key, "StringDemo|DateTimeDemo|RegexDemo"))
            {
                Console.WriteLine("请输入类型：StringDemo|DateTimeDemo|RegexDemo");
                key = Console.ReadLine();
            }
            IDemo demo = GetDemoInit(key);//反射获取Demo 
            demo.DemoTest();
#endif

#if bugger
            IDemo demo = new StringDemo();
            demo.DemoTest();
#endif

        }

        private static IDemo GetDemoInit(string key)
        {
            IDemo temp;
            /**************
            * Assembly.Load(程序集名).CreateInstance(命名空间.类名) 
            * 程序集下分多个命名空间，命名空间中包含多个类，为了区分同名类，命名空间就是唯一标识
            ***************/
            try
            {
                temp = (IDemo)Assembly.Load("CodeDemo").CreateInstance("CodeDemo." + key);
            }
            catch
            {
                temp = new RegexDemo();//默认显示string的
            }
            return temp;
        }


    }
}

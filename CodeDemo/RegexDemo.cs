using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeDemo
{
    public class RegexDemo : IDemo
    {
        public void DemoTest()
        {
            //string s = "21011212122334";
            //Regex reg = new Regex(@"^(\d{4})(\d{2})(\d{2})(\d{2})(\d{2})(\d{2})$");
            //Console.WriteLine(s);
            //Console.WriteLine(@"^(\d{4})(\d{2})(\d{2})(\d{2})(\d{2})(\d{2})$");
            //s = reg.Replace(s, "$1/$2/$3 $4:$5:$6");
            //Console.WriteLine(s);
            //$0 为整个正则表达式匹配到的结果 分段以（的顺序为准，并且支持嵌套，例如：（（）。。）（）（）$1比$2多两个字符

            //邮箱验证
            //string e = "tanglei@cass.org.cn";
            //Regex reg = new Regex(@"^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$");
            //Console.WriteLine(reg.IsMatch(e));


        }
    }
}

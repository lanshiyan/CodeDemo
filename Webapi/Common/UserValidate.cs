using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApi.Common
{
    public static class UserValidate
    {
        /// <summary>
        /// 根据FormsAuthenticationTicket来判断用户是否存在
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static bool ValidateUserTicket(string ticket)
        {
            var userticket = FormsAuthentication.Decrypt(ticket);
            if (userticket != null)
            {
                var userdata = userticket.UserData;
                int index = userdata.IndexOf(":", StringComparison.Ordinal);//分隔符要各处一致
                string username = userdata.Substring(0, index);
                string pwd = userdata.Substring(index + 1);
                //todo 验证用户名密码是否正确
                return true;
            }
            return false;
        }

        public static bool ValidateUser(string username, string pwd)
        {
            return true;
        }
    }
}
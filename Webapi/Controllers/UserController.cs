using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebApi.Common;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {

        [Route("user")]
        public UserInfo GetUserById(int id)
        {
            using (var db = new DBModel())
            {
                return db.UserInfos.FirstOrDefault(t => t.Id == id);
            }
        }

        [Route("login"),HttpPost]
        public bool LogIn(string username, string pwd)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pwd))
            {
                if (UserValidate.ValidateUser(username, pwd))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(20), true, username+":"+ pwd, "/");
                    var cookie = new HttpCookie(username, FormsAuthentication.Encrypt(ticket));
                    cookie.HttpOnly = true;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return true;
                }
            }
            return false;

        }
    }
}

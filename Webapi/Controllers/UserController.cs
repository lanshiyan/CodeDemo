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

        [Route("user"), BaseAuthentication]
        public UserInfo GetUserById(int id)
        {
            using (var db = new DBModel())
            {
                return db.UserInfos.FirstOrDefault(t => t.Id == id);
            }
        }

        [Route("login"),HttpGet]
        public string LogIn(string username, string pwd)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pwd))
            {
                var ticket = UserValidate.GetTicketByUserData(username, pwd);
                if (ticket != null)
                {
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    cookie.HttpOnly = true;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return $"sessionkey:{FormsAuthentication.Encrypt(ticket)}";
                }
            }
            return "";

        }
    }
}

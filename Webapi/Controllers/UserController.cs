﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    }
}

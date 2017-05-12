using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webapi.Models;

namespace Webapi.Controllers
{
    public class TestController : ApiController
    {
        TestModels[] Modelses = new[]
        {
            new TestModels() {id = 1,BirthDay = new DateTime(2010,1,12),Gender = true,Name="ceshi1"},
            new TestModels() {id =2,BirthDay = new DateTime(2010,2,12),Gender = true,Name="ceshi2"},
            new TestModels() {id = 3,BirthDay = new DateTime(2010,3,12),Gender = true,Name="ceshi3"},
            new TestModels() {id = 4,BirthDay = new DateTime(2010,4,12),Gender = true,Name="ceshi4"},
            new TestModels() {id = 5,BirthDay = new DateTime(2010,5,12),Gender = true,Name="ceshi5"},
        };
    }
}

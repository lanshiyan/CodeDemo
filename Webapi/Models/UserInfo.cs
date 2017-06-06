using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Column("username", TypeName = "varchar"), MaxLength(100)]
        public string Name { get; set; }

        public bool Sex { get; set; }

        public DateTime LogIntm { get; set; }

        [MaxLength(200)]
        public string Remark { get; set; }
    }
}
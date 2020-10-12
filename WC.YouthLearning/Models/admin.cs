using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WC.YouthLearning.Models
{
    public class admin
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "管理员帐号")]
        public string uname { get; set; }

        [Display(Name = "管理员密码")]
        public string pwd { get; set; }

      
    }
}

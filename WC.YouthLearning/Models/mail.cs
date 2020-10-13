using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WC.YouthLearning.Models
{
    public class mail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "学号")]
        public string sid { get; set; }

        [Display(Name = "邮箱账号")]
        public string smail { get; set; }

    }
}

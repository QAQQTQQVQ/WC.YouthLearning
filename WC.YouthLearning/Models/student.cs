using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.YouthLearning.Models
{
    public class student
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "学生姓名")]
        public string name { get; set; }

        [Display(Name = "学生学号")]
        public int sid { get; set; }

        [Display(Name = "发表时间")]
        public string time { get; set; }

        [Display(Name = "次数")]
        public int num { get; set; }

        [Display(Name = "是否提交")]
        public int sub { get; set; }
    }
}

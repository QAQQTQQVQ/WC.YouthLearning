using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.YouthLearning.DAL;
using WC.YouthLearning.Models;

namespace WC.YouthLearning.BLL
{
    public class StudentBll : BaseBll<student>,IStudentBll
    {
        public StudentBll(BaseDal<student> cd):base(cd)
        {
            CurrentDal = cd;
        }


        public int UpdataList(List<student> students)
        {
            foreach (var stu in students)
            {
                stu.time = "";
                stu.sub = 0;
                CurrentDal.Update(stu);
  
            }
            return DbSession.SaveChanges();//这里把SaveChanges方法提到了循环体外，自然就与数据库交互一次
        }
    }
}

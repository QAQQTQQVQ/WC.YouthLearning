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
            CurrentDal = cd;//666777
        }

        public int DeleteListByLogical(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}

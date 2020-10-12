using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.YouthLearning.DAL;
using WC.YouthLearning.Models;

namespace WC.YouthLearning.BLL
{
    public class AdminBll:BaseBll<admin>,IAdminBll
    {
        public AdminBll(BaseDal<admin> cd) : base(cd)
            {
                CurrentDal = cd;
            }
    }
}

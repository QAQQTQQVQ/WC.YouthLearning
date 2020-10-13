using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.YouthLearning.DAL;
using WC.YouthLearning.Models;

namespace WC.YouthLearning.BLL
{
    public class MailBll : BaseBll<mail>,IMailBll
    {
        public MailBll(BaseDal<mail> cd) : base(cd)
        {
            CurrentDal = cd;
        }
    }
}

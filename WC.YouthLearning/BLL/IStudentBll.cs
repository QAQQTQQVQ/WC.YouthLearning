using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.YouthLearning.Models;

namespace WC.YouthLearning.BLL
{
    public interface IStudentBll:IBaseBll<student>
    {
        int UpdataList(List<student> students);
    }
}

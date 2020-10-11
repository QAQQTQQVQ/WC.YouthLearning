using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.YouthLearning.DAL
{
    public interface IDbSession
    {
        int SaveChanges();
    }
}

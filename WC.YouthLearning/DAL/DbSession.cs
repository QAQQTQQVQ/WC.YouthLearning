using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.YouthLearning.DAL
{
    public class DbSession : IDbSession
    {
        public int SaveChanges()
        {
            return DbContentFactory.GetCurrentDbContent().SaveChanges();
        }
    }
}

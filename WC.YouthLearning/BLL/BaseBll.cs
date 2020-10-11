using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WC.YouthLearning.DAL;

namespace WC.YouthLearning.BLL
{
    public class BaseBll<T> where T : class, new()
    {
        private BaseDal<T> CurrentDal;
        public BaseBll(BaseDal<T> cd)
        {
            CurrentDal = cd;
        }
        //public abstract void SetCurrentDal();
        //public BaseBll()//基类的构造方法
        //{
        //    SetCurrentDal();//该方法由子类去实现
        //}
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
        }

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, whereLambda, orderByLambda, isAsc);
        }

        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }
        public bool Delete(int id)
        {
            CurrentDal.Detete(id);
            return DbSession.SaveChanges() > 0;
        }

        public int DeleteList(List<int> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Detete(id);
            }
            return DbSession.SaveChanges();//这里把SaveChanges方法提到了循环体外，自然就与数据库交互一次
        }

    }
}

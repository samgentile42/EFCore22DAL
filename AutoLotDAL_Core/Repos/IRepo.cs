using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AutoLotDAL_Core.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int Add(IList<T> entities);
        int Update(T entity);
        int Update(IList<T> entities);
        int Delete(int id, byte[] timestamp);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetSome(Expression<Func<T, bool>> where);
        List<T> GetAll();
        List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteNonQuery(string sql, object[] sqlParametersObjects);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
     public class BaseServiceOld<T> where T:class,new()
    {
         public AiegleSalary.Dal.IEFRepository<T> dalOld;

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            return dalOld.AddEntity(entity);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            return dalOld.UpdateEntity(entity);
        }

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool UpdateEntity(IEnumerable<T> entities)
        {
            return dalOld.UpdateEntity(entities);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteEntity(int ID)
        {
            return dalOld.DeleteEntity(ID);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            return dalOld.DeleteEntity(entity);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool DeleteEntity(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DeleteEntity(predicate);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool DeleteEntity(IEnumerable<T> entities)
        {
            return dalOld.DeleteEntity(entities);
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IList<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return dalOld.LoadEntities(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IList<T> LoadEntities(int pageIndex = 1, int pageSize = 30, Func<T, bool> whereLambda = null)
        {
            return dalOld.LoadEntities(pageIndex, pageSize, whereLambda);
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T FindByID(int ID)
        {
            return dalOld.FindByID(ID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
     public class BaseService<T> where T:class,new()
    {
         public AiegleSalary.Dal.EF6Repository<T> dal;

         #region 1.0 新增实体，返回受影响的行数 +  int Add(T model)
         /// <summary>
         /// 1.0 新增实体，返回受影响的行数
         /// </summary>
         /// <param name="model"></param>
         /// <returns>返回受影响的行数</returns>
         public int Add(T model)
         {
             return dal.Add(model);
         }
         #endregion

         #region 1.1 新增实体，返回对应的实体对象 + T AddReturnModel(T model)
         /// <summary>
         /// 1.1 新增实体，返回对应的实体对象
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public T AddReturnModel(T model)
         {             
             return dal.AddReturnModel(model);
         }
         #endregion

         #region 2.0 根据id删除 +  int Del(T model)
         /// <summary>
         /// 2.0 根据id删除
         /// </summary>
         /// <param name="model">必须包含要删除id的对象</param>
         /// <returns></returns>
         public int Del(T model)
         {
             return dal.Del(model);
         }
         #endregion

         #region 2.1 根据条件删除 + int DelBy(Expression<Func<T, bool>> delWhere)
         /// <summary>
         /// 2.1 根据条件删除
         /// </summary>
         /// <param name="delWhere"></param>
         /// <returns>返回受影响的行数</returns>
         public int DelBy(Expression<Func<T, bool>> delWhere)
         {
             return dal.DelBy(delWhere);
         }
         #endregion

         #region 3.0 修改实体 +  int Modify(T model)
         /// <summary>
         /// 修改实体
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int Modify(T model)
         {
             return dal.Modify(model);
         }

         public int Update(T model)
         {
             return dal.Update(model);
         }
         #endregion

         #region 3.1 修改实体，可修改指定属性 + int Modify(T model, params string[] propertyNames)
         /// <summary>
         /// 3.1 修改实体，可修改指定属性
         /// </summary>
         /// <param name="model"></param>
         /// <param name="propertyName"></param>
         /// <returns></returns>
         public int Modify(T model, params string[] propertyNames)
         {
             return dal.Modify(model, propertyNames);
         }
         #endregion

         #region 3.2 批量修改 + int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedPropertyNames)
         /// <summary>
         /// 3.2 批量修改
         /// </summary>
         /// <param name="model"></param>
         /// <param name="whereLambda"></param>
         /// <param name="modifiedPropertyNames"></param>
         /// <returns></returns>
         public int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedPropertyNames)
         {
             return dal.ModifyBy(model, whereLambda, modifiedPropertyNames);
         }
         #endregion

         #region 4.0 根据条件查询单个model + T GetModel(Expression<Func<T, bool>> whereLambda)
         /// <summary>
         /// 4.0 根据条件查询单个model
         /// </summary>
         /// <param name="whereLambda"></param>
         /// <returns></returns>
         public T GetModel(Expression<Func<T, bool>> whereLambda)
         {
             return dal.GetModel(whereLambda);
         }
         #endregion

         #region 4.1 根据条件查询单个model并排序  +  T GetModel<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
         /// <summary>
         /// 4.1 根据条件查询单个model并排序
         /// </summary>
         /// <typeparam name="TKey"></typeparam>
         /// <param name="whereLambda"></param>
         /// <param name="orderLambda"></param>
         /// <param name="isAsc"></param>
         /// <returns></returns>
         public T GetModel<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
         {
             return dal.GetModel<TKey>(whereLambda, orderLambda, isAsc);
         }
         #endregion

         #region  5.0 根据条件查询 + List<T> GetListBy(Expression<Func<T, bool>> whereLambda)
         /// <summary>
         /// 5.0 根据条件查询
         /// </summary>
         /// <param name="whereLambda"></param>
         /// <returns></returns>
         public List<T> GetListBy(Expression<Func<T, bool>> whereLambda)
         {
             return dal.GetListBy(whereLambda);
         }
         #endregion

         #region 5.1 根据条件查询，并排序 +  List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
         /// <summary>
         /// 5.1 根据条件查询，并排序
         /// </summary>
         /// <typeparam name="TKey"></typeparam>
         /// <param name="whereLambda"></param>
         /// <param name="orderLambda"></param>
         /// <param name="isAsc"></param>
         /// <returns></returns>
         public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
         {
             return dal.GetListBy<TKey>(whereLambda, orderLambda, isAsc);
         }
         #endregion

         #region 5.2 根据条件查询Top多少个，并排序 + List<T> GetListBy<TKey>(int top, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
         /// <summary>
         /// 5.2 根据条件查询Top多少个，并排序
         /// </summary>
         /// <typeparam name="TKey"></typeparam>
         /// <param name="top"></param>
         /// <param name="whereLambda"></param>
         /// <param name="orderLambda"></param>
         /// <param name="isAsc"></param>
         /// <returns></returns>
         public List<T> GetListBy<TKey>(int top, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
         {
             return dal.GetListBy<TKey>(top, whereLambda, orderLambda, isAsc);
         }
         #endregion

         #region  5.3 根据条件排序查询  双排序 + List<T> GetListBy<TKey1, TKey2>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey1>> orderLambda1, Expression<Func<T, TKey2>> orderLambda2, bool isAsc1 = true, bool isAsc2 = true)
         /// <summary>
         /// 5.3 根据条件排序查询  双排序
         /// </summary>
         /// <typeparam name="TKey1"></typeparam>
         /// <typeparam name="TKey2"></typeparam>
         /// <param name="whereLambda"></param>
         /// <param name="orderLambda1"></param>
         /// <param name="orderLambda2"></param>
         /// <param name="isAsc1"></param>
         /// <param name="isAsc2"></param>
         /// <returns></returns>
         public List<T> GetListBy<TKey1, TKey2>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey1>> orderLambda1, Expression<Func<T, TKey2>> orderLambda2, bool isAsc1 = true, bool isAsc2 = true)
         {
             return dal.GetListBy<TKey1, TKey2>(whereLambda, orderLambda1, orderLambda2, isAsc1, isAsc2);
         }
         #endregion

         #region 5.3 根据条件排序查询Top个数  双排序 + List<T> GetListBy<TKey1, TKey2>(int top, Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey1>> orderLambda1, Expression<Func<T, TKey2>> orderLambda2, bool isAsc1 = true, bool isAsc2 = true)
         /// <summary>
         ///  5.3 根据条件排序查询Top个数  双排序
         /// </summary>
         /// <typeparam name="TKey1"></typeparam>
         /// <typeparam name="TKey2"></typeparam>
         /// <param name="top"></param>
         /// <param name="whereLambda"></param>
         /// <param name="orderLambda1"></param>
         /// <param name="orderLambda2"></param>
         /// <param name="isAsc1"></param>
         /// <param name="isAsc2"></param>
         /// <returns></returns>
         public List<T> GetListBy<TKey1, TKey2>(int top, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey1>> orderLambda1, Expression<Func<T, TKey2>> orderLambda2, bool isAsc1 = true, bool isAsc2 = true)
         {
             return dal.GetListBy<TKey1, TKey2>(top, whereLambda, orderLambda1, orderLambda2, isAsc1, isAsc2);
         }
         #endregion

         #region 6.0 分页查询 + List<T> GetPagedList<TKey>
         /// <summary>
         /// 分页查询 + List<T> GetPagedList
         /// </summary>
         /// <typeparam name="TKey"></typeparam>
         /// <param name="pageIndex">页码</param>
         /// <param name="pageSize">页容量</param>
         /// <param name="whereLambda">条件 lambda表达式</param>
         /// <param name="orderBy">排序 lambda表达式</param>
         /// <returns></returns>
         public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc = true)
         {
             return dal.GetPagedList<TKey>(pageIndex, pageSize, whereLambda, orderByLambda, isAsc);
         }
         #endregion

         #region 6.1分页查询 带输出 +List<T> GetPagedList<TKey>
         /// <summary>
         /// 分页查询 带输出
         /// </summary>
         /// <typeparam name="TKey"></typeparam>
         /// <param name="pageIndex"></param>
         /// <param name="pageSize"></param>
         /// <param name="rowCount"></param>
         /// <param name="whereLambda"></param>
         /// <param name="orderBy"></param>
         /// <param name="isAsc"></param>
         /// <returns></returns>
         public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc = true)
         {
             return dal.GetPagedList<TKey>(pageIndex, pageSize,ref rowCount, whereLambda, orderByLambda, isAsc);
         }
         #endregion

         #region 6.2 分页查询 带输出 并支持双字段排序
         /// <summary>
         /// 分页查询 带输出 并支持双字段排序
         /// </summary>
         /// <typeparam name="TKey"></typeparam>
         /// <param name="pageIndex"></param>
         /// <param name="pageSize"></param>
         /// <param name="rowCount"></param>
         /// <param name="whereLambda"></param>
         /// <param name="orderByLambda1"></param>
         /// <param name="orderByLambda2"></param>
         /// <param name="isAsc1"></param>
         /// <param name="isAsc2"></param>
         /// <returns></returns>
         public List<T> GetPagedList<TKey1, TKey2>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey1>> orderByLambda1, Expression<Func<T, TKey2>> orderByLambda2, bool isAsc1 = true, bool isAsc2 = true)
         {
             return dal.GetPagedList<TKey1, TKey2>(pageIndex, pageSize,ref rowCount, whereLambda, orderByLambda1, orderByLambda2, isAsc1, isAsc2);
         }
         #endregion
    }
}

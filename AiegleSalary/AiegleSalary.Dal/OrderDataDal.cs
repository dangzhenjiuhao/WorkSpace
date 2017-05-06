using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Dal
{
    public class OrderDataDal
    {
        #region 获取订单数据
        /// <summary>
        /// 获取订单数据
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="listIndex"></param>
        /// <returns></returns>
        public OrderData GetOrderData(string orderNo, int listIndex)
        {
            SqlParameter prmOrderNo = new SqlParameter("@OrderNo", orderNo);
            SqlParameter prmListIndex = new SqlParameter("@ListIndex", listIndex);

            DbContext context = EFDbContextHelper.Context;
            var data = context.Database.SqlQuery<OrderData>("exec [GetOrderData] @OrderNo,@ListIndex", prmOrderNo, prmListIndex);
            if (data != null)
            {
                return data.ToList().FirstOrDefault();
            }
            return null;
        } 
        #endregion

        #region 删除订单数据
        /// <summary>
        /// 删除订单数据
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="flowType"></param>
        /// <returns></returns>
        public bool DeleteOrderData(string orderID,int flowType)
        {
            DbContext context = EFDbContextHelper.Context;
            try
            {
                var wpCardList = context.Set<T_WPCard>().Where(wp => wp.OrderID == orderID && wp.ListType == flowType);
                var empSalaryList = context.Set<T_EmpSalary>().Where(emp => emp.OrderID == orderID && emp.ListType == flowType);
                context.Set<T_WPCard>().RemoveRange(wpCardList);
                context.Set<T_EmpSalary>().RemoveRange(empSalaryList);
                int result = context.SaveChanges();
                if (result > 0)
	            {
		            return true;
	            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        } 
        #endregion


        public DataSet GetEmpSalaryListByCondition(string startTime, string endTime,string eID)
        {
            string sql = string.Empty;
            if (!string.IsNullOrEmpty(eID))
            {
                sql = string.Format("select 员工编码=EID,员工姓名=EName,薪资=sum(Salary) from (select Apdate,AA.OrderID,AA.WpCode,EID,EName,Salary from T_EmpSalary TES left join (Select distinct ApDate,Orderid,TB.ReMark,TP.wpCode from T_WPCard tp left join T_BasicWP TB on TP.wpCode = TB.WPCode ) AA on TES.OrderID = AA.OrderID and TES.WPCode = AA.wpCode ) BB where ApDate between '{0}' and '{1}' and (EID='{2}' or EName='{3}')  group by EID,EName", startTime, endTime, eID,eID);
            }
            else
            {
                sql = string.Format("select 员工编码=EID,员工姓名=EName,薪资=sum(Salary) from (select Apdate,AA.OrderID,AA.WpCode,EID,EName,Salary from T_EmpSalary TES left join (Select distinct ApDate,Orderid,TB.ReMark,TP.wpCode from T_WPCard tp left join T_BasicWP TB on TP.wpCode = TB.WPCode ) AA on TES.OrderID = AA.OrderID and TES.WPCode = AA.wpCode ) BB where ApDate between '{0}' and '{1}'  group by EID,EName", startTime, endTime, eID);
            }

            
            DataSet dSet = SqlHelper.ExecuteDataset(SqlHelper.GetConnSting(), CommandType.Text, sql,null);
            if (dSet!=null)
            {
                return dSet;
            }
            return null;
        }

        #region 获取订单明细
        /// <summary>
        /// 获取订单明细
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="flowType"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailsListByCondition(string startTime, string endTime, int flowType)
        {
            string sql = string.Format("Select 完工日期= ApDate,分单号=Orderid,工序名称=TB.ReMark,工序编码=TP.wpCode,数量=tp.Qty,单价=tb.Price, 合计=Tp.A3,人员=Tp.A2,薪资=replace(Tp.A4,'/','|') from T_WPCard tp left join T_BasicWP TB on TP.wpCode = TB.WPCode where len(A2)>0 and ApDate between '{0}' and '{1}' and ListType ={2} Order by TP.OrderID,TB.ID", startTime, endTime, flowType);
            DataSet dSet = SqlHelper.ExecuteDataset(SqlHelper.GetConnSting(), CommandType.Text, sql, null);
            if (dSet != null)
            {
                return dSet;
            }
            return null;
        } 
        #endregion

        public DataSet GetEmpSalaryDetailByCondition(string startTime, string endTime, string eID)
        {
            string sql = string.Empty;

            sql = string.Format("select 完工日期=Apdate,分单号=AA.OrderID,工序码=AA.WpCode,工序名称=AA.ReMark,员工编号=EID,员工姓名=EName,薪资=replace(Salary,'/','|') from T_EmpSalary TES left join (Select distinct ApDate,Orderid,TB.ReMark,TP.wpCode from T_WPCard tp left join T_BasicWP TB on TP.wpCode = TB.WPCode ) AA on TES.OrderID = AA.OrderID and TES.WPCode = AA.wpCode  where EID like  '{2}%' and ApDate between '{0}' and '{1}'", startTime, endTime, eID, eID);
            
            DataSet dSet = SqlHelper.ExecuteDataset(SqlHelper.GetConnSting(), CommandType.Text, sql, null);
            if (dSet != null)
            {
                return dSet;
            }
            return null;
        }
    }
}

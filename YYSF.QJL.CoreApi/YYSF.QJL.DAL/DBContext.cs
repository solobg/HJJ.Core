using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YYSF.QJL.DAL
{
    public class DbContext<T> where T : class, new()
    {
        public DbContext()
        {
            string connstr = "server=.;uid=sa;pwd=123456;database=Test";
            //#if NETFRAMEWORK
            //            connstr = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            //#elif NETCOREAPP
            //            connstr = "server=.;uid=sa;pwd=123456;database=Test"
            //#endif
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connstr,
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

        }
        //注意：不能写成静态的，不能写成静态的
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }


        public virtual int Add(T m)
        {
            //Db.SqlQueryable().to
            //Db.Ado.SqlQuery()
            //CurrentDb.AsInsertable()
            return CurrentDb.InsertReturnIdentity(m);
        }

        public virtual bool Delete(dynamic id)
        {
            //Db.Queryable<T>()
            return CurrentDb.DeleteById(id);
        }

        public virtual List<T> GetList(string where = "")
        {
            return CurrentDb.AsQueryable().With(SqlWith.NoLock).Where(where).ToList();

        }

        public virtual T GetSingle(string where = "")
        {
            return CurrentDb.AsQueryable().Where(where).Single();
        }

        public virtual T GetById(dynamic id)
        {
            return CurrentDb.GetById(id);

        }

        public virtual bool Update(T m)
        {
            return CurrentDb.Update(m);
        }

        public virtual PageResponse<T> GetPageList(List<IConditionalModel> conditionalList, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            var pagelist = CurrentDb.GetPageList(conditionalList, page, orderByExpression, orderByType);
            return new PageResponse<T>()
            {
                DataList = pagelist,
                TotalCount = page.PageCount
            };


        }
    }
}

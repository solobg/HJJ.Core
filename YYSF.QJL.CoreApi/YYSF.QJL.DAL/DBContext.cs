using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYSF.QJL.DAL.Entities;
using YYSF.QJL.Utils;

namespace YYSF.QJL.DAL
{
    public class DbContext<T> where T : class, new()
    {
        public DbContext()
        {
            string connstr = AppConfigHelper.AppSettings.ConnectionStrings;
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

        //Student对象
        public SimpleClient<Student> StudentDb { get { return new SimpleClient<Student>(Db); } }



    }
}

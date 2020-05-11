using System;
using System.Collections.Generic;
using System.Text;

namespace YYSF.QJL.Utils
{
    public class AppSettings
    {
        /// <summary>
        /// 数据库链接
        /// </summary>
        public string ConnectionStrings { get; set; }

        /// <summary>
        /// redis链接
        /// </summary>
        public string RedisUrl { get; set; }
    }
}

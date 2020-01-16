using Microsoft.Extensions.Configuration;
using System.IO;

namespace YYSF.QJL.CoreAPI
{
    /// <summary>
    /// 配置文件管理器
    /// </summary>
    public static class ConfigurationUtil
    {
        /// <summary>
        /// 
        /// </summary>
        public static IConfiguration Configuration { get; }
        static ConfigurationUtil()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

    }
}

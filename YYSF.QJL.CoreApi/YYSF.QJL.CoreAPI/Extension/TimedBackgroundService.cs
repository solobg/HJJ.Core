using log4net;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace YYSF.QJL.CoreAPI.Extension
{
    /// <summary>
    /// 后台定时任务
    /// </summary>
    public class TimedBackgroundService : BackgroundService
    {
        private readonly ILog _logger;
        public TimedBackgroundService(ILog log)
        {
            _logger = log;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            Timer timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
            return Task.CompletedTask;
        }

        private void DoWork(Object state)
        {
            _logger.Info(DateTime.Now.ToString());
        }
    }
}

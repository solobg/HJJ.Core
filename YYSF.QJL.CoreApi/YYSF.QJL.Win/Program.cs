using System;
using System.ServiceProcess;

namespace YYSF.QJL.Win
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase[] services = new ServiceBase[] { new Service1() };
            ServiceBase.Run(services);
        }
    }
}

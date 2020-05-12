using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace YYSF.QJL.Win
{
    partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            while (true)
            {
                
                WriteTxt($"现在时间{DateTime.Now}");
                Thread.Sleep(2000);
            }

        }

        protected override void OnStop()
        {
            WriteTxt($"结束{DateTime.Now}");
        }


        public void WriteTxt(string text)
        {
            string filename = System.AppDomain.CurrentDomain.BaseDirectory + @"\test.txt";

            File.AppendAllLines(filename, new List<string>() { text }, Encoding.UTF8);
        }

    }
}

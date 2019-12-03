using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYSF.QJL.Service;
using Newtonsoft.Json;
namespace YYSF.QJL.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            try
            {
                var service = new TestService();
                var list = service.GetList();
                return View(list);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
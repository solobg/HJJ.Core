using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YYSF.QJL.CoreAPI.Controllers
{
    /// <summary>
    /// Student
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public dynamic Login([FromBody]string username, string password)
        {
            return new
            {

            }
        }
    }
}

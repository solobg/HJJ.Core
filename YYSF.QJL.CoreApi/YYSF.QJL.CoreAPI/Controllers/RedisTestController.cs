using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YYSF.QJL.CoreAPI.Controllers
{
    /// <summary>
    /// redistest api
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisTestController : ControllerBase
    {
        /// <summary>
        /// redis Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get(string key)
        {
            return RedisHelper.Get(key);
        }

        /// <summary>
        /// redis set 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public string Set(string key, string value)
        {
            var result = RedisHelper.Set(key, value, 9999);
            return result.ToString();
        }
    }
}

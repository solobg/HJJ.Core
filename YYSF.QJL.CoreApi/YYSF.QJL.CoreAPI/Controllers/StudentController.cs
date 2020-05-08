using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YYSF.QJL.Models;
using YYSF.QJL.Service;

namespace YYSF.QJL.CoreAPI.Controllers
{
    /// <summary>
    /// Student
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService stuService = new StudentService();

        private readonly ILog _log;
        public StudentController(ILog log)
        {
            _log = log;
            _log.Info("this is a message");
        }
        //[HttpGet]
        //public GetStudentDetailResponse GetDetail([FromQuery]GetStudentDetailRequest request)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
 
        /// <summary>
        /// 查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public GetStudentListResponse GetList([FromQuery] GetStudentListRequest request)
        {
            try
            {
                var response = stuService.GetPageList(request);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        /// <summary>
        /// 新增/修改学生
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public AddStudentResponse Add([FromBody]AddStudentRequest request)
        {
            try
            {
                var response = stuService.AddStudent(request);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
;
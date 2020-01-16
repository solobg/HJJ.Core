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


        /// <summary>
        /// 查询学生列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public GetStudentListResponse GetStudentList([FromQuery] GetStudentListRequest request)
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
        public AddStudentResponse AddStudent([FromBody]AddStudentRequest request)
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
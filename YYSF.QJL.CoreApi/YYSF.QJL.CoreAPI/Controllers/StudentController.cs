using log4net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YYSF.QJL.Models;
using YYSF.QJL.Service;

namespace YYSF.QJL.CoreAPI.Controllers
{
    /// <summary>
    /// Student API
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ILog _log;
        private IStudentService stuService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="studentService"></param>
        public StudentController(ILog log, IStudentService studentService)
        {
            _log = log;
            stuService = studentService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public GetStudentDetailResponse GetDetail([FromQuery]GetStudentDetailRequest request)
        {
            try
            {
                var detail = stuService.GetDetail(request.Id);
                return new GetStudentDetailResponse()
                {
                    IsSuccess = true,
                    VM = detail
                };

            }
            catch (Exception ex)
            {
                _log.Error($"【Student/GetDetail】" + JsonConvert.SerializeObject(request), ex);
                return new GetStudentDetailResponse() { Message = "error" };
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public GetStudentListResponse GetPageList([FromQuery] GetStudentListRequest request)
        {
            try
            {
                var response = stuService.GetPageList(request);
                return response;
            }
            catch (Exception ex)
            {
                _log.Error($"【Student/GetList】" + JsonConvert.SerializeObject(request), ex);
                return new GetStudentListResponse() { Message = "error" };
            }
        }



        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public AddStudentResponse Add([FromBody]AddStudentRequest request)
        {
            try
            {
                var response = stuService.Add(request);
                return response;
            }
            catch (Exception ex)
            {
                _log.Error($"【Student/Add】" + JsonConvert.SerializeObject(request), ex);
                return new AddStudentResponse() { Message = "error" };
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Update([FromBody]UpdateStudentRequest request)
        {
            try
            {
                var response = stuService.Update(request);
                return response;
            }
            catch (Exception ex)
            {
                _log.Error($"【Student/Add】" + JsonConvert.SerializeObject(request), ex);
                return new AddStudentResponse() { Message = "error" };
            }
        }
    }
}
;
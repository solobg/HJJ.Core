using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYSF.QJL.DAL;
using YYSF.QJL.Models;
using YYSF.QJL.Service.Mapping;

namespace YYSF.QJL.Service
{
    public class StudentService
    {

        private readonly StudentDao studao = new StudentDao();
        private readonly StudentMapper stumapper = new StudentMapper();
        public List<StudentVM> GetList()
        {
            var daolist = studao.GetList();
            var vmlist = stumapper.ConvertToVMList(daolist).ToList();
            return vmlist;
        }

        public AddStudentResponse AddStudent(StudentVM vm)
        {
            var result = studao.Add(stumapper.ConvertToEN(vm));
            return new AddStudentResponse()
            {
                IsSuccess = true
            };
        }

        public GetStudentListResponse GetPageList(GetStudentListRequest request)
        {
            List<IConditionalModel> conModels = new List<IConditionalModel>();
            if (!string.IsNullOrEmpty(request.SName))
            {
                conModels.Add(new ConditionalModel() { FieldName = "Name", FieldValue = request.SName, ConditionalType = ConditionalType.Like });
            }
            var response = studao.GetPageList(conModels, new PageModel() { PageIndex = request.PageIndex, PageSize = request.PageSize }, a => a.Id, OrderByType.Asc);
            return new GetStudentListResponse()
            {
                DataList = stumapper.ConvertToVMList(response.DataList).ToList(),
                IsSuccess = true,
                Message = "success",
                TotalCount = response.TotalCount
            };
        }
    }
}

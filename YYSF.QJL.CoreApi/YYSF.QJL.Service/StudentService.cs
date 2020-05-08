using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYSF.QJL.DAL;
using YYSF.QJL.DAL.Entities;
using YYSF.QJL.Models;
using YYSF.QJL.Service.Mapping;

namespace YYSF.QJL.Service
{
    public class StudentService : DbContext<Student>
    {

        private readonly StudentMapper stumapper = new StudentMapper();
        public List<StudentVM> GetList()
        {
            var daolist = CurrentDb.GetList();
            var vmlist = stumapper.ConvertToVMList(daolist).ToList();
            return vmlist;
        }

        public AddStudentResponse AddStudent(StudentVM vm)
        {
            var id = CurrentDb.InsertReturnIdentity(stumapper.ConvertToEN(vm));
            return new AddStudentResponse()
            {
                IsSuccess = true
            };
        }

        public GetStudentListResponse GetPageList(GetStudentListRequest request)
        {
            List<IConditionalModel> conModels = new List<IConditionalModel>();
            var query = CurrentDb.AsQueryable()
                .WhereIF(!string.IsNullOrWhiteSpace(request.SName), a => a.Name == request.SName);
            var totalCount = 0;
            var list = query.ToPageList(request.PageIndex, request.PageSize, ref totalCount);
            return new GetStudentListResponse()
            {
                DataList = stumapper.ConvertToVMList(list).ToList(),
                IsSuccess = true,
                Message = "success",
                TotalCount = totalCount
            };
        }
    }
}

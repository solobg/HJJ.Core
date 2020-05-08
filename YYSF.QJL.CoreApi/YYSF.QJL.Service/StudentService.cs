using AutoMapper;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYSF.QJL.DAL;
using YYSF.QJL.DAL.Entities;
using YYSF.QJL.Models;

namespace YYSF.QJL.Service
{
    public interface IStudentService
    {
        List<StudentVM> GetList();

        GetStudentListResponse GetPageList(GetStudentListRequest request);

        AddStudentResponse AddStudent(StudentVM vm);
    }
    public class StudentService : DbContext<Student>, IStudentService
    {
        private IMapper _mapper;
        public StudentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<StudentVM> GetList()
        {
            var daolist = CurrentDb.GetList();
            var vmlist = _mapper.Map<List<StudentVM>>(daolist);
            return vmlist;
        }

        public AddStudentResponse AddStudent(StudentVM vm)
        {
            var m = _mapper.Map<Student>(vm);
            var id = CurrentDb.InsertReturnIdentity(m);
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
            var vmlist = _mapper.Map<List<StudentVM>>(list);
            var list2 = _mapper.Map<List<Student>>(vmlist);
            return new GetStudentListResponse()
            {
                DataList = vmlist ,
                IsSuccess = true,
                Message = "success",
                TotalCount = totalCount
            };
        }
    }
}

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

        AddStudentResponse Add(StudentVM vm);

        BaseResponse Update(StudentVM vm);

        BaseResponse Delete(int id);

        StudentVM GetDetail(int id);
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

        public AddStudentResponse Add(StudentVM vm)
        {
            var m = _mapper.Map<Student>(vm);
            var id = CurrentDb.InsertReturnIdentity(m);
            return new AddStudentResponse()
            {
                IsSuccess = true,
                Id = id,
                Message = "success"
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
                DataList = vmlist,
                IsSuccess = true,
                Message = "success",
                TotalCount = totalCount
            };
        }

        public BaseResponse Update(StudentVM vm)
        {
            var m = _mapper.Map<Student>(vm);
            CurrentDb.Update(m);
            return new BaseResponse()
            {
                IsSuccess = true,
                Message = "success"
            };
        }

        public BaseResponse Delete(int id)
        {
            var m = CurrentDb.GetById(id);
            if (m == null || m.Id <= 0)
            {
                return new BaseResponse() { Message = "id not found" };
            }
            CurrentDb.DeleteById(id);
            return new BaseResponse()
            {
                IsSuccess = true,
                Message = "success"
            };

        }

        public StudentVM GetDetail(int id)
        {
            var m = CurrentDb.GetById(id);
            return _mapper.Map<StudentVM>(m);
        }
    }
}

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
    public class TestService
    {

        private readonly StudentDao studao = new StudentDao();
        private readonly StudentMapper stumapper = new StudentMapper();
        public List<StudentVM> GetList()
        {
            var daolist = studao.GetList();
            var vmlist = stumapper.ConvertToVMList(daolist).ToList();
            return vmlist;
        }

        public bool AddStudent(StudentVM vm)
        {
            var result = new StudentDao().Add(stumapper.ConvertToEN(vm));
            return result;
        }

        public PageResponse<StudentVM> GetPageList()
        {
            new StudentDao().GetPageList("")
        }
    }
}

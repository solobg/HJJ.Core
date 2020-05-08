using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYSF.QJL.Models
{
    public class StudentVM
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public string CreateTime { get; set; }
    }

    public class AddStudentResponse : BaseResponse
    {

        public int Id { get; set; }
    }

    public class AddStudentRequest : StudentVM
    {

    }

    public class UpdateStudentRequest : StudentVM
    {

    }

    /// <summary>
    /// Getstudent
    /// </summary>
    public class GetStudentListRequest : BasePageRequest
    {
        /// <summary>
        /// ceshi
        /// </summary>
        public string SName { get; set; }
    }

    public class GetStudentDetailRequest
    {
        public int Id { get; set; }
    }

    public class GetStudentDetailResponse : BaseResponse
    {

        public StudentVM VM { get; set; }
    }

    public class GetStudentListResponse : PageResponse<StudentVM>
    {

    }
}

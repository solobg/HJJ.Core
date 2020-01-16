using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYSF.QJL.DAL
{
    public class PageResponse<T> where T : class
    {
        public int TotalCount { get; set; }

        public List<T> DataList { get; set; }
    }
}

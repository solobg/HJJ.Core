using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace YYSF.QJL.DAL.Entities
{
    [SugarTable("Student")]
    public class Student
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        
        public string Name { get; set; }


        public int Age { get; set; }
    }
}

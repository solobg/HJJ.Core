using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YYSF.QJL.DAL.Entities;
using YYSF.QJL.Models;

namespace YYSF.QJL.CoreAPI.Extension
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Student, StudentVM>()
                .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.CreateTime, opt => opt.MapFrom(src => src.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")))
                ;

            CreateMap<StudentVM, Student>().ForMember(des => des.Name, opt => opt.MapFrom(src => src.UserName))
         ;


        }
    }
}

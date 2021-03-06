﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYSF.QJL.DAL.Entities;
using YYSF.QJL.Models;
using YYSF.QJL.Utils.Helper;

namespace YYSF.QJL.Service.Mapping
{
    public class StudentMapper : BaseMapper<Student, StudentVM>
    {
        public override Student ConvertToEN(StudentVM vm, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {
            cfgExp = cfg => cfg.CreateMap<StudentVM, Student>().ForMember(b => b.Name, c => c.MapFrom(src => src.UserName));
            var en = vm.AutoMapTo<StudentVM, Student>(cfgExp);
            return en;
        }

        public override List<Student> ConvertToENList(IEnumerable<StudentVM> vlist, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {

            cfgExp = cfg => cfg.CreateMap<StudentVM, Student>().ForMember(b => b.Name, c => c.MapFrom(src => src.UserName));
            return vlist.AutoMapToList<StudentVM, Student>(cfgExp);
        }

        public override StudentVM ConvertToVM(Student en, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {
            var vm = en.AutoMapTo<Student, StudentVM>(cfgExp);
            vm.UserName = en.Name;
            return vm;
        }

        public override List<StudentVM> ConvertToVMList(IEnumerable<Student> elist, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {
            cfgExp = cfg => cfg.CreateMap<Student, StudentVM>()
            .ForMember(b => b.UserName, c => c.MapFrom(src => src.Name));
            return elist.AutoMapToList<Student, StudentVM>(cfgExp);
        }
    }
}

using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYSF.QJL.Utils.Helper
{
    public static class AutoMapHelper
    {

        /// <summary>
        ///  类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public static TDestination AutoMapTo<TDestination>(this object obj)
        //{
        //    if (obj == null) return default(TDestination);
        //    var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap(obj.GetType(), typeof(TDestination)));
        //    return config.CreateMapper().Map<TDestination>(obj);
        //}


        /// <summary>
        /// 集合列表类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination">转化之后的实体对象，可以理解为viewmodel</typeparam>
        /// <typeparam name="TSource">要被转化的实体对象，Entity</typeparam>
        /// <param name="source">通过泛型指定的这个扩展方法的类型，理论任何引用类型</param>
        /// <returns>转化之后的实体列表</returns>
        public static List<TDestination> AutoMapToList<TSource, TDestination>(this IEnumerable<TSource> source, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
            where TDestination : class
            where TSource : class
        {
            if (source == null) return new List<TDestination>();
            var config = new AutoMapper.MapperConfiguration(cfgExp != null ? cfgExp : cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 类型映射,可指定映射字段的配置信息
        /// </summary>
        /// <typeparam name="TSource">源数据：要被转化的实体对象</typeparam>
        /// <typeparam name="TDestination">目标数据：转换后的实体对象</typeparam>
        /// <param name="source">任何引用类型对象</param>
        /// <param name="cfgExp">可为null，则自动一一映射</param>
        /// <returns></returns>
        public static TDestination AutoMapTo<TSource, TDestination>(this TSource source, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
         where TDestination : class
         where TSource : class
        {
            if (source == null) return default(TDestination);
            var config = new AutoMapper.MapperConfiguration(cfgExp != null ? cfgExp : cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }



        ///// <summary>
        ///// 类型映射,默认字段名字一一对应
        ///// </summary>
        ///// <typeparam name="TSource">源数据：要被转化的实体对象</typeparam>
        ///// <typeparam name="TDestination">目标数据：转换后的实体对象</typeparam>
        ///// <param name="source">任何引用类型对象</param>
        ///// <returns>转化之后的实体</returns>
        //public static TDestination AutoMapTo<TSource, TDestination>(this TSource source)
        //    where TDestination : class
        //    where TSource : class
        //{
        //    if (source == null) return default(TDestination);
        //    var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
        //    var mapper = config.CreateMapper();
        //    return mapper.Map<TDestination>(source);
        //}


        ///// <summary>
        ///// 集合列表类型映射,默认字段名字一一对应
        ///// </summary>
        ///// <typeparam name="TDestination">转化之后的实体对象，可以理解为viewmodel</typeparam>
        ///// <typeparam name="TSource">要被转化的实体对象，Entity</typeparam>
        ///// <param name="source">通过泛型指定的这个扩展方法的类型，理论任何引用类型</param>
        ///// <returns>转化之后的实体列表</returns>
        //public static IEnumerable<TDestination> AutoMapTo<TSource, TDestination>(this IEnumerable<TSource> source)
        //    where TDestination : class
        //    where TSource : class
        //{
        //    if (source == null) return new List<TDestination>();
        //    var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
        //    var mapper = config.CreateMapper();
        //    return mapper.Map<List<TDestination>>(source);
        //}



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYSF.QJL.Utils.Helper;
namespace YYSF.QJL.Service.Mapping
{
    public interface IBaseMapper<E, V> where E : class where V : class
    {
        V ConvertToVM(E e, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null);

        E ConvertToEN(V v, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null);

        List<V> ConvertToVMList(IEnumerable<E> elist, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null);

        List<E> ConvertToENList(IEnumerable<V> vlist, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null);

    }

    public abstract class BaseMapper<E, V> : IBaseMapper<E, V> where E : class where V : class
    {
        public virtual E ConvertToEN(V v, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {
            return v.AutoMapTo<V, E>(cfgExp);
        }

        public virtual List<E> ConvertToENList(IEnumerable<V> vlist, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {
            return vlist.AutoMapToList<V, E>(cfgExp);
        }

        public virtual V ConvertToVM(E e, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {
            return e.AutoMapTo<E, V>(cfgExp);
        }

        public virtual List<V> ConvertToVMList(IEnumerable<E> elist, Action<AutoMapper.IMapperConfigurationExpression> cfgExp = null)
        {
            return elist.AutoMapToList<E, V>(cfgExp);
        }
    }

}

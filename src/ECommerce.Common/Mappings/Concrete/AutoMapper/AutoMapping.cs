using AutoMapper;
using ECommerce.Common.Mappings.Abstract;

namespace ECommerce.Common.Mappings.Concrete.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapping : IKanberskyMapping
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<TSource, TDestination>());

            var mapper = new Mapper(config);
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}

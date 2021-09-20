using AutoMapper;
using ECommerce.Common.Mappings.Abstract;

namespace ECommerce.Application.Mappings.AutoMapper
{
    public class AutoMapping : IKanberskyMapping
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return mapper.Map<TDestination>(source);
        }
    }
}

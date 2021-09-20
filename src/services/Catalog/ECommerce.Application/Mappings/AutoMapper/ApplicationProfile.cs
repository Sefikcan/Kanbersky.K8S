using AutoMapper;
using ECommerce.Application.DTO.Response;
using ECommerce.Infrastructure.Entities;

namespace ECommerce.Application.Mappings.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Product, ProductResponseModel>().ReverseMap();
        }
    }
}

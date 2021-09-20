using ECommerce.Application.DTO.Response;
using ECommerce.Common.Caching.Abstract;
using ECommerce.Common.Mappings.Abstract;
using ECommerce.Infrastructure.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Queries
{
    public class GetProductsQuery : IRequest<List<ProductResponseModel>>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponseModel>>
    {
        private readonly ICacheService _cacheService;
        private readonly IKanberskyMapping _mapper;

        public GetProductsQueryHandler(ICacheService cacheService,
            IKanberskyMapping mapper)
        {
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var response = await _cacheService.GetAsync("test") as List<Product>;
            return _mapper.Map<List<Product>, List<ProductResponseModel>>(response);
        }
    }
}

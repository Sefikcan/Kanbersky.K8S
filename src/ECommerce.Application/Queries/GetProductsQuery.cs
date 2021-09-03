using ECommerce.Application.DTO.Response;
using ECommerce.Common.Mappings.Abstract;
using ECommerce.Infrastructure.DbContext;
using ECommerce.Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly ECommerceDbContext _context;
        private readonly IKanberskyMapping _mapper;

        public GetProductsQueryHandler(ECommerceDbContext context,
            IKanberskyMapping mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Products.ToListAsync();
            return _mapper.Map<List<Product>, List<ProductResponseModel>>(response);
        }
    }
}

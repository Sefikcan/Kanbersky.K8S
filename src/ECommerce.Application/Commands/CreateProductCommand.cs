using ECommerce.Application.DTO.Request;
using ECommerce.Application.DTO.Response;
using ECommerce.Common.Caching.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductResponseModel>
    {
        public CreateProductRequestModel CreateProductRequest { get; set; }

        public CreateProductCommand(CreateProductRequestModel createProductRequest)
        {
            CreateProductRequest = createProductRequest;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseModel>
    {
        private readonly ICacheService _cacheService;

        public CreateProductCommandHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<ProductResponseModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _cacheService.AddAsync($"test", request.CreateProductRequest, 3000);
            return new ProductResponseModel
            {
                Id = request.CreateProductRequest.Id,
                Name = request.CreateProductRequest.Name,
                Price = request.CreateProductRequest.Price
            };
        }
    }
}

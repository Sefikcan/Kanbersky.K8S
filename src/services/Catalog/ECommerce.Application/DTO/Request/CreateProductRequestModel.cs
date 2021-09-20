using System;

namespace ECommerce.Application.DTO.Request
{
    public class CreateProductRequestModel
    {
        public CreateProductRequestModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}

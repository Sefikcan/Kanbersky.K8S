using System;

namespace ECommerce.Application.DTO.Response
{
    public class ProductResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}

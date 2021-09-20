using ECommerce.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Infrastructure.Entities
{
    [Table("products", Schema = "products")]
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}

using ECommerce.Common.Settings.Abstract;

namespace ECommerce.Common.Settings.Concrete
{
    public class ProductDbSettings : ISettings
    {
        public string ConnectionString { get; set; }
    }
}

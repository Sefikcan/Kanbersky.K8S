using ECommerce.Common.Settings.Abstract;

namespace ECommerce.Common.Settings.Concrete
{
    public class ProductDbSettings : ISettings
    {
        public string Host { get; set; }

        public int Port { get; set; }
    }
}

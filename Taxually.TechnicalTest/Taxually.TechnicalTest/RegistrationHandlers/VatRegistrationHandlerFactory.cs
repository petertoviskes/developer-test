using Taxually.TechnicalTest.RegistrationHandler;

namespace Taxually.TechnicalTest.RegistrationHandlers
{
    public class VatRegistrationHandlerFactory : IVatRegistrationHandlerFactory
    {
        private readonly IServiceProvider serviceProvider;

        public VatRegistrationHandlerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IVatRegistrationHandler CreateHandler(string country)
        {
            return country switch
            {
                "GB" => (IVatRegistrationHandler)serviceProvider.GetService(typeof(HttpVatRegistrationHandler)),
                "FR" => (IVatRegistrationHandler)serviceProvider.GetService(typeof(CsvVatRegistrationHandler)),
                "DE" => (IVatRegistrationHandler)serviceProvider.GetService(typeof(XmlVatRegistrationHandler)),
                _ => throw new Exception("Country not supported"),
            };
        }
    }
}

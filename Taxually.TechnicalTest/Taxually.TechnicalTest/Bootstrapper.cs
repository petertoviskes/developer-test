using Taxually.TechnicalTest.RegistrationHandler;
using Taxually.TechnicalTest.RegistrationHandlers;

namespace Taxually.TechnicalTest
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IVatRegistrationHandlerFactory, VatRegistrationHandlerFactory>();

            services.AddScoped<CsvVatRegistrationHandler>()
              .AddScoped<IVatRegistrationHandler, CsvVatRegistrationHandler>(s => s.GetService<CsvVatRegistrationHandler>());

            services.AddScoped<XmlVatRegistrationHandler>()
                .AddScoped<IVatRegistrationHandler, XmlVatRegistrationHandler>(s => s.GetService<XmlVatRegistrationHandler>());

            services.AddScoped<HttpVatRegistrationHandler>()
                .AddScoped<IVatRegistrationHandler, HttpVatRegistrationHandler>(s => s.GetService<HttpVatRegistrationHandler>());

            services.AddScoped<ITaxuallyHttpClient, TaxuallyHttpClient>();
            services.AddScoped<ITaxuallyQueueClient, TaxuallyQueueClient>();
        }
    }
}

using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.RegistrationHandler
{
    public class HttpVatRegistrationHandler : IVatRegistrationHandler
    {
        private readonly ITaxuallyHttpClient taxuallyHttpClient;

        public HttpVatRegistrationHandler(ITaxuallyHttpClient taxuallyHttpClient)
        {
            this.taxuallyHttpClient = taxuallyHttpClient;
        }

        public async Task Register(VatRegistrationRequest registrationRequest)
        {
            await taxuallyHttpClient.PostAsync("https://api.uktax.gov.uk", registrationRequest);
        }
    }
}

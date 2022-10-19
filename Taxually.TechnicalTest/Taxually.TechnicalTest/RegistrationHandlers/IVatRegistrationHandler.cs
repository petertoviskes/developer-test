using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.RegistrationHandler
{
    public interface IVatRegistrationHandler
    {
        Task Register(VatRegistrationRequest registrationRequest);
    }
}
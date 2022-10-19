using Taxually.TechnicalTest.RegistrationHandler;

namespace Taxually.TechnicalTest.RegistrationHandlers
{
    public interface IVatRegistrationHandlerFactory
    {
        IVatRegistrationHandler CreateHandler(string country);
    }
}
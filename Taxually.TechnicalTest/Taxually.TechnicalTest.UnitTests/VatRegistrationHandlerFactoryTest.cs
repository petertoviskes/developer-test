using Taxually.TechnicalTest.RegistrationHandlers;

namespace Taxually.TechnicalTest.UnitTests
{
    public class VatRegistrationHandlerFactoryTest
    {
        VatRegistrationHandlerFactory target;
      
        public VatRegistrationHandlerFactoryTest()
        {
            target = new VatRegistrationHandlerFactory(null);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Unknown")]
        [InlineData("gb")]
        public async Task GivenUnsupportedCountry_WhenRegistrationHandlerCreated_ItThrows(string country)
        {
            var exception = Assert.Throws<Exception>(() => target.CreateHandler(country));
            Assert.Equal("Country not supported", exception.Message);
        }
    }
}
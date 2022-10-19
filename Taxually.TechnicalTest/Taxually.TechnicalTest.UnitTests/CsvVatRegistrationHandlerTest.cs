using NSubstitute;
using System.Text;
using Taxually.TechnicalTest.Model;
using Taxually.TechnicalTest.RegistrationHandler;

namespace Taxually.TechnicalTest.UnitTests
{
    public class CsvVatRegistrationHandlerTest
    {
        CsvVatRegistrationHandler target;
        ITaxuallyQueueClient queueClient;

        public CsvVatRegistrationHandlerTest()
        {
            queueClient = NSubstitute.Substitute.For<ITaxuallyQueueClient>();
            target = new CsvVatRegistrationHandler(queueClient);
        }

        [Fact]
        public async Task GivenFRRequest_WhenRegistationRequested_ThanCsvPlacedInQueue()
        {
            //Arrange
            var request = new VatRegistrationRequest()
            {
                CompanyId = "c1",
                CompanyName = "name",
                Country = "FR"
            };
            byte[] calledWith = null;
            queueClient.EnqueueAsync("vat-registration-csv", Arg.Any<byte[]>());

            //Act
            await target.Register(request);

            //Assert
            string expectedCsv = $"CompanyName,CompanyId\r\n{request.CompanyName},{request.CompanyId}\r\n";
            var expectedArray = Encoding.UTF8.GetBytes(expectedCsv );

            queueClient
                .Received()
                .EnqueueAsync("vat-registration-csv", Arg.Is<byte[]>(x => x.SequenceEqual(expectedArray)));
        }
    }
}
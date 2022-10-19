using System.Text;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.RegistrationHandler
{
    public class CsvVatRegistrationHandler : IVatRegistrationHandler
    {
        private readonly ITaxuallyQueueClient excelQueueClient;

        public CsvVatRegistrationHandler(ITaxuallyQueueClient excelQueueClient)
        {
            this.excelQueueClient = excelQueueClient;
        }

        public async Task Register(VatRegistrationRequest registrationRequest)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{registrationRequest.CompanyName},{registrationRequest.CompanyId}");//<-comma added
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            // Queue file to be processed
            await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);
        }
    }
}

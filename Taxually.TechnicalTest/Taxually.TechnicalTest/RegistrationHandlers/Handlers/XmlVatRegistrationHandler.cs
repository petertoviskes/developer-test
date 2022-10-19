using System.Xml.Serialization;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.RegistrationHandler
{
    public class XmlVatRegistrationHandler : IVatRegistrationHandler
    {
        private readonly ITaxuallyQueueClient taxuallyQueueClient;

        public XmlVatRegistrationHandler(ITaxuallyQueueClient taxuallyQueueClient)
        {
            this.taxuallyQueueClient = taxuallyQueueClient;
        }

        public async Task Register(VatRegistrationRequest registrationRequest)
        {
            // Germany requires an XML document to be uploaded to register for a VAT number
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringwriter, registrationRequest);//<-this has been replaced by the registration request
                var xml = stringwriter.ToString();
                // Queue xml doc to be processed
                await taxuallyQueueClient.EnqueueAsync("vat-registration-xml", xml);
            }
        }
    }
}

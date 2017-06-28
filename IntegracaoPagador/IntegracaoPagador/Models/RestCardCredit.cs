using IntegracaoPagador.Models.Interface;

namespace IntegracaoPagador.Models
{
    public class RestCardCredit : IRestCardCredit
    {
        public string MerchantOrderId { get; set; }

        public Customer Customer { get; set; }

       public Payment Payment { get; set; }
    }
}

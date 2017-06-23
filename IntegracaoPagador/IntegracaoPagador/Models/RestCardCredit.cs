namespace IntegracaoPagador.Models
{
    public class RestCardCredit
    {
        public string MerchantOrderId { get; set; }

        public Customer Customer { get; set; }

       public Payment Payment { get; set; }
    }
}

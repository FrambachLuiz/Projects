using IntegracaoPagador.Models.Interface;

namespace IntegracaoPagador.Models
{
    public class Payment : IPayment
    {
        public string Type { get; set; }
        public string Amount { get; set; }
        public string Provider { get; set; }
        public string Installments { get; set; }
        public CreditCard CreditCard { get; set; }
        public string PaymentId { get; set; }
        public byte Status { get; set; }
    }
}

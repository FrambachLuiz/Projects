namespace IntegracaoPagador.Models.Interface
{
    public interface IPayment
    {
        string Amount { get; set; }
        CreditCard CreditCard { get; set; }
        string Installments { get; set; }
        string PaymentId { get; set; }
        string Provider { get; set; }
        string Type { get; set; }

         byte Status { get; set; }
    }
}
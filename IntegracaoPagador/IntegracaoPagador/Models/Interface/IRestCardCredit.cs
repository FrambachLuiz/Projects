namespace IntegracaoPagador.Models.Interface
{
    public interface IRestCardCredit
    {
        Customer Customer { get; set; }
        string MerchantOrderId { get; set; }
        Payment Payment { get; set; }
    }
}
namespace IntegracaoPagador.Models.Interface
{
    public interface ICreditCard
    {
        string Brand { get; set; }
        string CardNumber { get; set; }
        string ExpirationDate { get; set; }
        string Holder { get; set; }
        string SecurityCode { get; set; }
    }
}
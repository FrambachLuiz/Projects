using System.ComponentModel.DataAnnotations;


namespace IntegracaoPagador.ViewModels
{
    public class SoapViewModel
    {

        //Fixas
        public string MerchanId { get; set; }
        public short PaymentMethod { get; }
        public int TypePayment { get; }
        public string OrderId { get; set; }


        //Obrigatorios
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [StringLength(25)]
        public string Holder { get; set; }

        [Required]
        [StringLength(19)]
        public string CardNumber { get; set; }

        [Required]
        public string Expiration { get; set; }

        [Required]
        [StringLength(4)]
        public string SecurityCode { get; set; }

        [Required]
        public int NumberPayments { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        [Required]
        [StringLength(3)]
        public string Country { get; set; }

        //Optativos
        public string PaymentMethodName { get; set; }
        public string Identity { get; set; }
        public string CustomerIdentityType { get; set; }
        public string CustomerEmail { get; set; }

        public byte Status { get; set; }

        public SoapViewModel()
        {
            OrderId = "TesteSimulado";
            MerchanId = "94E5EA52-79B0-7DBA-1867-BE7B081EDD97";
            PaymentMethod = 997;
            TypePayment = 0;
        }
    }
}
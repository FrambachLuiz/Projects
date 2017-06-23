using System.ComponentModel.DataAnnotations;

namespace IntegracaoPagador.ViewModels
{
    public class RestViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Provider { get; set; }

        [Required]
        public int Installments { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Holder { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        [Required]
        public string Brand { get; set; }
    }
}
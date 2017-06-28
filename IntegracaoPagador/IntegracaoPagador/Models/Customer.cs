using System;
using IntegracaoPagador.Models.Interface;

namespace IntegracaoPagador.Models
{
    public class Customer : ICustomer
    {
        public String Name { get; set; }
    }
}

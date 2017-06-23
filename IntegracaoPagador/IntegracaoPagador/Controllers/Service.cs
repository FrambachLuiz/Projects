using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace IntegracaoPagador.Controllers
{
    public class Service
    {
        static HttpClient client;
        public int Type { get; set; }

        //Inicializando a API
        public Service(int type)
        {
            Type = type;
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            if (type == 1)
            {
                client.BaseAddress = new Uri("https://transaction.pagador.com.br/webservices/pagador/Pagador.asmx");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
  
            }
            else
            {
                client.BaseAddress = new Uri("https://apihomolog.braspag.com.br/v2/sales");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            }




        }

        //Método para authorizar o cartão
        [HttpPost]
        public async Task<object> Authorize(string dadosCartao)
        {
            HttpResponseMessage response = null;

            var a = new ServicePagadorSoap.CustomerDataRequest();
            var b = new ServicePagadorSoap.AdditionalDataRequest();
            var c = new ServicePagadorSoap.AffiliationDataRequest();
            var d = new ServicePagadorSoap.AuthorizeTransactionRequest();
            var e = new ServicePagadorSoap.AuthorizeTransactionResponse();
          



            response = client.PostAsJsonAsync("https://transaction.pagador.com.br/webservices/pagador/Pagador.asmx?op=Authorize", dadosCartao).Result;
             
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                response.EnsureSuccessStatusCode();
            }
            else
            {
                MessageBox.Show("falhou");
            }

            return dadosCartao;
        }
    }
}
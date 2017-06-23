using IntegracaoPagador.Models;
using IntegracaoPagador.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System.Web.Mvc;

namespace IntegracaoPagador.Controllers
{
    public class RestController : Controller
    {
        private RestClient Client { get; set; }

        private new RestRequest Request { get; set; }


        public ActionResult Inicio()
        {
            var viewModel = new RestViewModel();

            return View("Rest", viewModel);

        }

        [HttpPost]
        public ActionResult Authorize(RestViewModel viewModel)
        {
            return View("RestCapture",
                Transaction(Transaction(AddingParameters(viewModel))));
        }

        //Adding parameters to json
        public RestCardCredit AddingParameters(RestViewModel viewModel)
        {
            var creditCard = new CreditCard
            {
                CardNumber = viewModel.CardNumber.Replace(".", ""),
                Holder = viewModel.Holder,
                ExpirationDate = viewModel.ExpirationDate,
                SecurityCode = viewModel.SecurityCode,
                Brand = viewModel.Brand
            };

            var payment = new Payment
            {
                Type = viewModel.Type,
                Amount = viewModel.Amount.ToString(),
                Provider = viewModel.Provider,
                Installments = viewModel.Installments.ToString(),
                CreditCard = creditCard
            };

            var customer = new Customer
            {
                Name = viewModel.Name
            };

            var restCardCredit = new RestCardCredit
            {
                MerchantOrderId = "123456",
                Customer = customer,
                Payment = payment
            };

            return restCardCredit;
        }

        //Post Transaction
        public string Transaction(object content)
        {
            Client = new RestClient("https://apisandbox.braspag.com.br");
            Request = new RestRequest("v2/sales")
            {
                Method = Method.POST,
            };
            AddHeader(Request);
            Request.AddJsonBody(content);
            var resultContent = JsonConvert.DeserializeObject<RestCardCredit>(Client.Execute(Request).Content);


            return resultContent.Payment.PaymentId;
        }

        //Get Transaction
        private RestViewModel Transaction(string content)
        {
            Client = new RestClient("https://apiquerysandbox.braspag.com.br/");
            Request = new RestRequest("v2/sales/" + content)
            {
                Method = Method.GET
            };
            AddHeader(Request);

            return AddParameterRestViewModel(
                JsonConvert.DeserializeObject<RestCardCredit>(
                    Client.Execute(Request).Content));
        }

        public void AddHeader(RestRequest request)
        {
            request.AddHeader("MerchantId", "94E5EA52-79B0-7DBA-1867-BE7B081EDD97");
            request.AddHeader("MerchantKey", "0123456789012345678901234567890123456789");
            request.AddHeader("RequestId", "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx");
        }

        public RestViewModel AddParameterRestViewModel(RestCardCredit resultContent)
        {
            var viewResult = new RestViewModel
            {
                Name = resultContent.Customer.Name,
                Type = resultContent.Payment.Type,
                Amount = int.Parse(resultContent.Payment.Amount),
                Provider = resultContent.Payment.Provider,
                Installments = int.Parse(resultContent.Payment.Installments),
                CardNumber = resultContent.Payment.CreditCard.CardNumber,
                Holder = resultContent.Payment.CreditCard.Holder,
                ExpirationDate = resultContent.Payment.CreditCard.ExpirationDate,
                SecurityCode = resultContent.Payment.CreditCard.SecurityCode,
                Brand = resultContent.Payment.CreditCard.Brand
            };

            return viewResult;
        }

    }
}
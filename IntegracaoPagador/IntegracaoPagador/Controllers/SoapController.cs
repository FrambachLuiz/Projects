using IntegracaoPagador.PagadorSoapService;
using IntegracaoPagador.ViewModels;
using System;
using System.Web.Mvc;
using System.Windows.Forms;

namespace IntegracaoPagador.Controllers
{
    public class SoapController : Controller
    {
        public ActionResult Inicio()
        {
            var viewModel = new SoapViewModel();

            return View("Soap", viewModel);

        }

        [HttpPost]
        public ActionResult Authorize(SoapViewModel viewModel)
        {
            var service = new PagadorTransactionSoapClient();
            var response = service.AuthorizeTransaction(AddingAuthorizeParameters(viewModel));

            if (response.Success)
            {
                var viewReturn = GetOrder(response.OrderData.BraspagOrderId);

                return View("SoapCapture", viewReturn);
            }

            MessageBox.Show("Algo deu errado!");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Authorize(string content , string amount )
        {
            var response = CaptureOrder(content);

          //  if (response.Success)
         //   {
                
          //      var viewReturn = GetOrder(response.OrderData.BraspagOrderId);

           //     return View("SoapCapture", viewReturn);
          //  }

            MessageBox.Show("Algo deu errado!");
            return RedirectToAction("Index", "Home");
        }


        //POST PARAMETERS
        public AuthorizeTransactionRequest AddingAuthorizeParameters(SoapViewModel soapCreditCard)
        {
            var serviceOrderData = new OrderDataRequest
            {
                MerchantId = new Guid(soapCreditCard.MerchanId),
                OrderId = "0000"
            };

            var serviceCustomer = new CustomerDataRequest
            {
                CustomerIdentity = soapCreditCard.Identity,
                CustomerIdentityType = soapCreditCard.CustomerIdentityType,
                CustomerName = soapCreditCard.CustomerName,
                CustomerEmail = soapCreditCard.CustomerEmail

            };

            var servicePayment = new CreditCardDataRequest
            {
                PaymentMethod = soapCreditCard.PaymentMethod,
                Amount = soapCreditCard.Amount,
                Currency = soapCreditCard.Currency,
                Country = soapCreditCard.Country,
                NumberOfPayments = (short)soapCreditCard.NumberPayments,
                PaymentPlan = 0, // cash
                TransactionType = 1, // preauth
                CardHolder = soapCreditCard.CustomerName,
                CardNumber = soapCreditCard.CardNumber,
                CardSecurityCode = soapCreditCard.SecurityCode,
                CardExpirationDate = soapCreditCard.Expiration
            };

            var authorizationRequest = new AuthorizeTransactionRequest
            {
                RequestId = new Guid("00000000-0000-0000-0000-000000000000"),
                Version = "1.0",
                CustomerData = serviceCustomer,
                OrderData = serviceOrderData,
                PaymentDataCollection = new PaymentDataRequest[] { servicePayment }
            };

            return authorizationRequest;
        }


        //GET SERVICE
        public SoapViewModel GetOrder(Guid orderId)
        {
            object soapModel = null;

            var serviceOrderDataRequest =
                new PagadorQuery.OrderDataRequest
                {
                    MerchantId = new Guid("94E5EA52-79B0-7DBA-1867-BE7B081EDD97"),
                    BraspagOrderId = orderId,
                    RequestId = new Guid("94E5EA52-79B0-7DBA-1867-BE7B081EDD97"),
                    Version = "1.0"
                };

            var service = new PagadorQuery.PagadorQuerySoapClient();
            var resultGet = service.GetOrderData(serviceOrderDataRequest);

            if (!resultGet.Success) return null;

            var collection = resultGet.TransactionDataCollection[0];
            soapModel = new SoapViewModel
            {
                Amount = (int)collection.Amount,
                Country = collection.Country,
                CardNumber = collection.MaskedCardNumber,
                PaymentMethodName = collection.PaymentMethodName,
                Currency = collection.Currency,
                NumberPayments = collection.NumberOfPayments
            };

            return (SoapViewModel) soapModel;
        }


        //CAPTURE SERVICE
        public ActionResult CaptureOrder(string merchanId)
        {
            var service = new PagadorTransactionSoapClient();
            var response = service.CaptureCreditCardTransaction(AddingCaptureParameters(merchanId));

            if (response.Success)
            {
                var viewReturn = GetOrder(response.CorrelationId);

                return View("SoapCapture", viewReturn);
            }

            MessageBox.Show("Algo deu errado!");
            return RedirectToAction("Index", "Home");
        }

        private static CaptureCreditCardTransactionRequest AddingCaptureParameters(string merchanId)
        {
            var transactionData = new TransactionDataRequest
            {
                BraspagTransactionId = new Guid(merchanId)
            };

           var captureRequest = new CaptureCreditCardTransactionRequest
            {
                RequestId = new Guid("00000000-0000-0000-0000-000000000000"),
                Version = "1.0",
                MerchantId = new Guid(merchanId),
                TransactionDataCollection = new[] { transactionData }
           };

            return captureRequest;
        }
    }
}
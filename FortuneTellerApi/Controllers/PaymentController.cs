using Elfie.Serialization;
using FortuneTellerApi.Models;
using FortuneTellerApi.Models.Iyzico;
using FortuneTellerApi.Utility;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Options = Iyzipay.Options;

namespace FortuneTellerApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly APIDbContext _context;

        public PaymentController(APIDbContext context)
        {
            _context = context;
        }
        
        private string _callbackUrl { get; set; } = "https://www.merchant.com/callback";
        private string _currency { get; set; } = "TRY";


        [HttpPost]
        public async Task<IActionResult> Pay(PaymentRequest payment)
        {
            bool isSuccess = false;
            UserDetail userDetail = _context.UserDetails.FirstOrDefault(x => x.UserId == payment.UserId);
            UserAddress userRegisterAddress = _context.UserAddress.FirstOrDefault(x => x.AddressId == userDetail.RegistrationAddressId);
            UserAddress userBillingAddress = _context.UserAddress.FirstOrDefault(x => x.AddressId == payment.BillingAddressId);
            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            Options options = new Options();
            if (userDetail.IsValid() && userRegisterAddress.IsValid() && userBillingAddress.IsValid())
            {                
                options.ApiKey = "sandboxKey"; // for testing
                options.SecretKey = "sandboxSecretKey";// for testing
                options.BaseUrl = "https://sandbox-api.iyzipay.com";

                request.Locale = Locale.TR.ToString();
                request.ConversationId = payment.ConversationId;
                request.Price = payment.Price;
                request.PaidPrice = payment.PaidPrice;
                request.Currency = _currency;
                request.BasketId = payment.BasketId;
                request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
                request.CallbackUrl = _callbackUrl;

                List<int> enabledInstallments = new List<int>();
                enabledInstallments.Add(2);
                enabledInstallments.Add(3);
                enabledInstallments.Add(6);
                enabledInstallments.Add(9);
                request.EnabledInstallments = enabledInstallments;

                if (userDetail != null)
                {
                    Buyer buyer = new Buyer();
                    buyer.Id = userDetail.UserId.ToString();
                    buyer.Name = userDetail.Name;
                    buyer.Surname = userDetail.Surname;
                    buyer.GsmNumber = userDetail.Surname;
                    buyer.Email = userDetail.Email;
                    buyer.IdentityNumber = userDetail.IdentityNumber;
                    buyer.LastLoginDate = userDetail.LastLoginDate;
                    buyer.RegistrationDate = userDetail.RegistrationDate;
                    buyer.RegistrationAddress = userRegisterAddress.Description;
                    buyer.Ip = payment.UserIp;
                    buyer.City = userRegisterAddress.City;
                    buyer.Country = userRegisterAddress.Country;
                    buyer.ZipCode = userRegisterAddress.ZipCode;
                    request.Buyer = buyer;
                    Address billingAddress = new Address();
                    billingAddress.ContactName = userDetail.Name + " " + userDetail.Surname;
                    billingAddress.City = userBillingAddress.City;
                    billingAddress.Country = userBillingAddress.Country;
                    billingAddress.Description = userBillingAddress.Description;
                    billingAddress.ZipCode = userBillingAddress.ZipCode;
                    request.BillingAddress = billingAddress;

                }
                List<BasketItem> basketItems = payment.BasketItems;
               

            }
            else
            {
                BadRequest();
            }
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            if (checkoutFormInitialize.Status == "success")
            {
                return Ok(checkoutFormInitialize);
            }

            return BadRequest(checkoutFormInitialize);

        }

        //[HttpPost]
        //public async Task<IActionResult> PayCallBack()
        //{

        //}
    }
}

using FortuneTellerApi.Utility;
using Iyzipay.Model;
using Newtonsoft.Json;
using System.Net;

namespace FortuneTellerApi.Models.Iyzico
{
    public partial class PaymentRequest
    {
       
        public string ConversationId { get; set; }

        
        public string Price { get; set; }

        public string BasketId { get; set; }

        public int UserId { get; set; }
  
        public int BillingAddressId { get; set; }
   
        public List<BasketItem> BasketItems { get; set; }

        public string PaidPrice { get; set; }

        public string UserIp { get; set; }
    }


    public partial class PaymentRequest
    {
        public static PaymentRequest FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PaymentRequest>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this PaymentRequest self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

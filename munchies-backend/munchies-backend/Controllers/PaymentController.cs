using munchies_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace munchies_backend.Controllers
{
    public class PaymentController : ApiController
    {
        private string paymentGatewayBase = WebConfigurationManager.AppSettings["baseUrl"];
        private string confirmationBase = WebConfigurationManager.AppSettings["success_failed_cancle_base"];

        string Baseurl = WebConfigurationManager.AppSettings["baseUrl"] + "/request.php";

        [HttpPost]
        [Route("api/payment")]
        public async Task<HttpResponseMessage> Payment(TransactionModel t)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                var person = new TransactionModel();
                
                person.tran_id = Guid.NewGuid().ToString().Remove(0, 4);
                person.amount = t.amount;
                person.cus_name = t.cus_name;
                person.cus_email = t.cus_email;
                person.cus_phone = t.cus_phone;

                person.success_url = confirmationBase + "/index.php/contact-us";
                person.fail_url = confirmationBase + "/index.php/pricing";
                person.cancel_url = confirmationBase + "/index.php/payment-solutions/qrpayment";
                
                PropertyInfo[] infos = person.GetType().GetProperties();

                foreach (PropertyInfo pair in infos)
                {
                    string name = pair.Name;
                    var value = pair.GetValue(person, null);

                    parameters.Add(pair.Name, value.ToString());
                }
                using (var client = new HttpClient())
                {
                    HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);

                    using (
                        var result =
                            await client.PostAsync(Baseurl, DictionaryItems))
                    {
                        var input = await result.Content.ReadAsStringAsync();
                        var trans = input.Remove(0, 2).Split('"')[0];

                        string url = paymentGatewayBase + trans;

                        return Request.CreateResponse(HttpStatusCode.OK, url);
                    }
                }
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.OK, e.Message);
            }
        }
    }
}

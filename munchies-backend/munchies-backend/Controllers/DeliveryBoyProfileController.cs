using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace munchies_backend.Controllers
{
    public class DeliveryBoyProfileController : ApiController
    {
        [HttpPost]
        [Route("api/DeliveryBoyProfile/create")]
        public HttpResponseMessage Create(DeliveryBoyProfileDTO s)
        {
            DeliveryBoyProfileService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/DeliveryBoyProfile/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = DeliveryBoyProfileService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/DeliveryBoyProfile/all")]
        public HttpResponseMessage Get()
        {
            var data = DeliveryBoyProfileService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}

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
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("api/Registration/create")]
        public HttpResponseMessage Create(RegistrationDTO s)
        {
            RegistrationService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/Regitration/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = RegistrationService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/Registration/all")]
        public HttpResponseMessage Get()
        {
            var data = RegistrationService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpDelete]
        [Route("api/Registration/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            RegistrationService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

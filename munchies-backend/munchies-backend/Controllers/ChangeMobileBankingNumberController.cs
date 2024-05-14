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
    public class ChangeMobileBankingNumberController : ApiController
    {
        [HttpPost]
        [Route("api/ChangeMobileBankingNumber/create")]
        public HttpResponseMessage Create(ChangeMobileBankingNumberDTO s)
        {
            ChangeMobileBankingNumberService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/ChangeMobileBankingNumber/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ChangeMobileBankingNumberService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/ChangeMobileBankingNumber/all")]
        public HttpResponseMessage Get()
        {
            var data = ChangeMobileBankingNumberService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpPut]
        [Route("api/ChangeMobileBankingNumber/update/{id}")]
        public HttpResponseMessage Update(int id, ChangeMobileBankingNumberDTO s)
        {
            ChangeMobileBankingNumberService.Update(id, s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

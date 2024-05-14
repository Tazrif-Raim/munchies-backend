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
    public class LogisticController : ApiController
    {

        [HttpPost]
        [Route("api/logistic/create")]
        public HttpResponseMessage Create(LogisticDTO s)
        {
            LogisticService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/logistic/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = LogisticService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/logistic/all")]
        public HttpResponseMessage Get()
        {
            var data = LogisticService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpPut]
        [Route("api/logistic/update/{id}")]
        public HttpResponseMessage Update(int id, LogisticDTO s)
        {
            LogisticService.Update(id, s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/logistic/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            LogisticService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

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
    public class OrderLocationController : ApiController
    {
        [HttpPost]
        [Route("api/location/create")]
        public HttpResponseMessage Create(OrderLocationDTO s)
        {
            OrderLocationService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/location/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = OrderLocationService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/location/all")]
        public HttpResponseMessage Get()
        {
            var data = OrderLocationService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [HttpPut]
        [Route("api/location/update/{id}")]
        public HttpResponseMessage Update(int id, OrderLocationDTO s)
        {
            OrderLocationService.Update(id, s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/location/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            OrderLocationService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

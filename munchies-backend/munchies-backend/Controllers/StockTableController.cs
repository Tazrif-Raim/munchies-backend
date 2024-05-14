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
    public class StockTableController : ApiController
    {
        [HttpPost]
        [Route("api/stock/create")]
        public HttpResponseMessage Create(StockTableDTO s)
        {
            StockTableService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/stock/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = StockTableService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/stock/all")]
        public HttpResponseMessage Get()
        {
            var data = StockTableService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpPut]
        [Route("api/stock/update/{id}")]
        public HttpResponseMessage Update(int id, StockTableDTO s)
        {
            StockTableService.Update(id, s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/stock/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            StockTableService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

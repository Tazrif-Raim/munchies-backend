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
    public class ReviewController : ApiController
    {
        [HttpPost]
        [Route("api/review/create")]
        public HttpResponseMessage Create(ReviewDTO s)
        {
            ReviewService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/review/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ReviewService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/review/all")]
        public HttpResponseMessage Get()
        {
            var data = ReviewService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [HttpPut]
        [Route("api/review/update/{id}")]
        public HttpResponseMessage Update(int id, ReviewDTO s)
        {
            ReviewService.Update(id, s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/review/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            ReviewService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }

}

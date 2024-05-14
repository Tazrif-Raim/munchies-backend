using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.ApplicationServices;

namespace munchies_backend.Controllers
{
    public class ProfileController : ApiController
    {
        [HttpPost]
        [Route("api/profile/create")]
        public HttpResponseMessage Create(ProfileDTO s)
        {
            BLL.Services.ProfileService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/profile/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = BLL.Services.ProfileService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/profile/all")]
        public HttpResponseMessage Get()
        {
            var data = BLL.Services.ProfileService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpPut]
        [Route("api/profile/update/{id}")]
        public HttpResponseMessage Update(int id, ProfileDTO s)
        {
            BLL.Services.ProfileService.Update(id, s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/profile/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            BLL.Services.ProfileService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
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
    public class CreateUser : ApiController
    {
        /*[HttpPost]
        [Route("api/CreateUser/create")]
        public HttpResponseMessage Create(CreateUserDTO s)
        {
            CreateUserService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/CreateUser/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = CreateUserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/CreateUser/all")]
        public HttpResponseMessage Get()
        {
            var data = CreateUserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpPut]
        [Route("api/CreateUser/update/{id}")]
        public HttpResponseMessage Update(int id, CreateUserDTO s)
        {
            CreateUserService.Update(id, s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/createUser/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            CreateUserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }*/
    }
}

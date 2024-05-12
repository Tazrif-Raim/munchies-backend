using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealFoods.Controllers
{
    public class MealController : ApiController
    {
        /*[HttpGet]
        [Route("api/meals")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, MealService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }*/
        [HttpPost]
        [Route("api/meal/create")]
        public HttpResponseMessage Create(MealDTO s)
        {
            MealService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/meal/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = MealService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/meal/all")]
        public HttpResponseMessage Get()
        {
            var data = MealService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}

using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealFoods.Controllers
{
    public class ResturantController : ApiController
    {
        [HttpGet]
        [Route("api/resturants")]

        public HttpResponseMessage Resturants()
        {
            try
            {
                var data = ResturantService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}

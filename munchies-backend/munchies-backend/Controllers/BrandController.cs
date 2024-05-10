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
    public class BrandController : ApiController
    {
        [HttpGet]
        [Route("api/brands")]
        public HttpResponseMessage Brands()
        {
            try
            {
                var data = BrandService.GetAllBrands();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {message = e.Message});
            }
        }

        [HttpPost]
        [Route("api/setBrand")]
        public HttpResponseMessage Setbrand(BrandDTO brand)
        {
            BrandService.setBrand(brand);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}

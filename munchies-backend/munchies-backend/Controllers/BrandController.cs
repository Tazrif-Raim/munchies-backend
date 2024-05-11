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
            try
            {
                BrandService.setBrand(brand);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {message = e.Message});
            }
        }

        [HttpGet]
        [Route("api/getBrand")]
        public HttpResponseMessage GetBrand(Guid id)
        {
            try
            {
                var data = BrandService.getBrandInfo(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {message = e.Message});
            }
        }

        [HttpPost]
        [Route("api/setBrandRecipe")]
        public HttpResponseMessage SetBrandRecipe(BrandRecipeDTO brand)
        {
            try
            {
                foreach (var item in brand.Recipes)
                {
                    if(item.Brand_Id == Guid.Empty || item.Brand_Id == null)
                    {
                        item.Brand_Id = brand.Id;
                    }
                    RecipeService.updateBrand(item);
                }
                BrandService.setBrandRecipe(brand);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {message = e.Message});
            }
        }
    }
}

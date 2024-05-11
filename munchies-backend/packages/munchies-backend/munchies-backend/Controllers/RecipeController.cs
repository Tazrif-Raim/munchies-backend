using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace munchies_backend.Controllers
{
    public class RecipeController : ApiController
    {
        [HttpPost]
        [Route("api/setRecipe")]
        public async Task<HttpResponseMessage> SetRecipe()
        {
            var mime = "";
            try
            {
                var provider = new MultipartFormDataStreamProvider(Path.GetTempPath());
                await Request.Content.ReadAsMultipartAsync(provider);

                var recipeJson = provider.FormData["recipe"];
                var recipe = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipeDTO>(recipeJson);

                mime = provider.Contents[0].Headers.ContentType.MediaType;

                var file = provider.FileData.Count > 0 ? provider.FileData[0] : null;
                if(file != null)
                {
                    var videoFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.Headers.ContentDisposition.FileName.Trim('"'));
                    
                    var videoFilePath = Path.Combine("C:\\Users\\Admin\\Desktop\\munchies-backend\\munchies-backend\\videos", videoFileName);
                    
                    File.Move(file.LocalFileName, videoFilePath);

                    recipe.videoPath = videoFilePath;
                    recipe.Id = Guid.NewGuid();
                    var ingredients = recipe.Ingredients;

                    foreach (var item in ingredients)
                    {
                        item.Id = Guid.NewGuid();
                    }

                    recipe.Ingredients = ingredients;

                    RecipeService.setRecipe(recipe);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "recipe received");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message = ex.Message, m = mime});
            }
        }


        [HttpGet]
        [Route("api/recipeVideo")]

        public async Task<HttpResponseMessage> GetRecipeVideo(string videoPath)
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK);
                var videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

                response.Content = new StreamContent(videoStream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        /*public HttpResponseMessage GetRecipeVideo(string videoPath)
        {
            try
            {
                var video = File.ReadAllBytes(videoPath);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(video);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");
                return response;
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message = ex.Message});
            }
        }*/

        [HttpGet]
        [Route("api/getRecipes")]
        public HttpResponseMessage GetRecipes()
        {
            try
            {
                var recipes = RecipeService.getRecipes();
                return Request.CreateResponse(HttpStatusCode.OK, recipes);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message = ex.Message});
            }
        }
    }
}

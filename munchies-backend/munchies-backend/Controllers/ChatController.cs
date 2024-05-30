using BLL.DTOs;
using BLL.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace munchies_backend.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChatController : ApiController
    {
        string projectId = "c32f0f8c-0e9d-4d3e-9886-198a38713ce2";
        string privateKey = "1607da3b-6308-4bf2-902b-bc232beaf0ac";

        [HttpPost]
        [Route("api/signup")]
        
        public async Task<HttpResponseMessage> Signup(ChatProfileDTO chatProfile)
        {
            try
            {
                var serverPassCheck = ChatUserService.checkServerPassword(chatProfile.serverPassword);
                if(serverPassCheck == false)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Server password is incorrect" });
                }
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Private-Key", privateKey);
                    var chatProfileToSend = new { 
                        username = chatProfile.username, 
                        secret = chatProfile.secret,
                        email = chatProfile.email,
                        first_name = chatProfile.first_name,
                        last_name = chatProfile.last_name
                    };
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(chatProfileToSend);
                    HttpResponseMessage response = await client.PostAsync("https://api.chatengine.io/users/", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var reponseData = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    chatProfile.Id = reponseData.id;
                    ChatUserService.setChatProfile(chatProfile);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }

        }

        [HttpPost]
        [Route("api/login")]
        
        public async Task<HttpResponseMessage> Login(ChatProfileDTO chatProfile)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Project-ID", projectId);
                    client.DefaultRequestHeaders.Add("User-Name", chatProfile.username);
                    client.DefaultRequestHeaders.Add("User-Secret", chatProfile.secret);
                    var response = await client.GetAsync("https://api.chatengine.io/users/me/");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject(responseBody);

                        return Request.CreateResponse(response.StatusCode, responseObject, "application/json");
                    }
                    else
                    {
                        return Request.CreateResponse(response.StatusCode, new { message = response.ReasonPhrase });
                    }
                }
            } 
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/deleteUser")]
        public async Task<HttpResponseMessage> DeleteUser(ChatProfileDTO chatProfile)
        {
            try
            {
                var serverPassCheck = ChatUserService.checkServerPassword(chatProfile.serverPassword);
                if (serverPassCheck == false)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Server password is incorrect" });
                }
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Private-Key", privateKey);

                    var userId = chatProfile.Id;
                    HttpResponseMessage response = await client.DeleteAsync($"https://api.chatengine.io/users/{userId}");

                    ChatUserService.deleteChatProfile(chatProfile.Id.ToString());

                    return response;
                }
            }
            catch (HttpRequestException ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/updateServerPassword")]
        public HttpResponseMessage UpdateServerPassoword(PassChangeDTO pass)
        {
            try
            {
                ChatUserService.setServerPassword(pass.oldPassword, pass.newPassword);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getUsers")]
        public HttpResponseMessage GetUsers()
        {
            try
            {
                var users = ChatUserService.getChatProfiles();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

    }
}

using BLL.DTOs;
using BLL.Services;
using munchies_backend.Auth;
using munchies_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace munchies_backend.Controllers
{
    public class userController : ApiController
    {
        private int getID(HttpRequestMessage request)
        {
            string tokenString = request.Headers.Authorization.ToString();
            return authService.authorizeUser(tokenString).userid;
        }
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage login(loginDTO login)
        {
            var tk = authService.userLogin(login.username, login.password);
            if (tk != null)
            {
                var message = new
                {
                    userrole = authService.getUserByTokenID(tk.id).userRole,
                    token = tk
                };
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid credential" });
        }
        [HttpPost]
        [Route("logout")]
        [userAuth]
        public HttpResponseMessage logout()
        {
            string tokenString = Request.Headers.Authorization.ToString();
            if (authService.userLogout(tokenString))
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Successfully logout" });
            return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Logout b" });
        }
        [HttpPatch]
        [Route("changepassword")]
        [userAuth]
        public HttpResponseMessage changePassword(changePasswordDTO cpObj)
        {
            int userID = getID(Request);
            if (authService.changePassword(userID, cpObj.oldPassword, cpObj.newPassword))
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Password is changed successfully" });
            return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Password changing was unsuccessfull" });
        }
        [HttpGet]
        [Route("profile")]
        [userAuth]
        public HttpResponseMessage profile()
        {
            try
            {
                int userID = getID(Request);
                var data = userServices.getProfile(userID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("registerCustomer")]
        public HttpResponseMessage registerCustomer(customerDTO customer)
        {
            try
            {
                userServices.AddCustomer(customer);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
    }
}

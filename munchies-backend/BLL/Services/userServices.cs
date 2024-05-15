using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class userServices
    {
        public static userDTO getProfile(int userID)
        {
            var userObj = DataAccessFactory.getUser().Read(userID);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<user, userDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<userDTO>(userObj);
        }

        public static bool usernameExist(string username)
        {
            var data = DataAccessFactory.getUser().Read().Where(u => u.username.Equals(username)).ToList();
            return data.Count > 0;
        }

        public static bool AddAdmin(AdminDTO admin)
        {
            var cfg = new MapperConfiguration(c => 
            {
                c.CreateMap<AdminDTO, user>();
                c.CreateMap<AdminDTO, Admin>();
            });
            var mapper = cfg.CreateMapper();
            var userObj = mapper.Map<user>(admin);
            userObj.userRole = "admin";
            userObj = DataAccessFactory.getUser().Create(userObj);
            var adminObj = mapper.Map<Admin>(admin);
            adminObj.id = userObj.id;
            return DataAccessFactory.AdminData().Create(adminObj) != null;
        }

        public static bool AddCustomer(customerDTO customer)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<customerDTO, user>();
                c.CreateMap<customerDTO, Customer>();
            });
            var mapper = cfg.CreateMapper();
            var userObj = mapper.Map<user>(customer);
            userObj.userRole = "customer";
            userObj = DataAccessFactory.getUser().Create(userObj);
            var cusObj = mapper.Map<Customer>(customer);
            cusObj.id = userObj.id;
            return DataAccessFactory.customerData().Create(cusObj) != null;
        }
    }
}

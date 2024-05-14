using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CreateUserService
    {
        public static void Create(CreateUserDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateUserDTO, CreateUser>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<CreateUser>(s);
            DataAccessFactory.CreateUserData().Create(cnv);
        }
        public static CreateUserDTO Get(int id)
        {

            var data = DataAccessFactory.CreateUserData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateUser, CreateUserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CreateUserDTO>(data);
        }
        public static List<CreateUserDTO> Get()
        {
            var data = DataAccessFactory.CreateUserData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateUser, CreateUserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CreateUserDTO>>(data);

        }
        public static void Update(int id, CreateUserDTO UpdateCreateUser)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUserDTO, CreateUser>();
            });
            var mapper = new Mapper(config);
            var updatedCreateUserEntity = mapper.Map<CreateUser>(UpdateCreateUser);
            updatedCreateUserEntity.id = id;
            DataAccessFactory.CreateUserData().Update(updatedCreateUserEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.CreateUserData().Delete(id);
        }

    }
}

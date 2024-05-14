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
    public class RegistrationService
    {
        public static void Create(RegistrationDTO registrationDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RegistrationDTO, Registration>();
            });
            var mapper = new Mapper(config);
            var registration = mapper.Map<Registration>(registrationDto);
            DataAccessFactory.RegistrationData().Create(registration);
        }

        public static RegistrationDTO Get(int id)
        {
            var data = DataAccessFactory.RegistrationData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistrationDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<RegistrationDTO>(data);
        }

        public static List<RegistrationDTO> GetAll()
        {
            var data = DataAccessFactory.RegistrationData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistrationDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<RegistrationDTO>>(data);
        }

        public static void Update(int id, RegistrationDTO registrationDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistrationDTO, Registration>();
            });
            var mapper = new Mapper(config);
            var updatedRegistration = mapper.Map<Registration>(registrationDto);
            updatedRegistration.RegistrationId = id; // assuming RegistrationId is the ID property in your Registration entity
            DataAccessFactory.RegistrationData().Update(updatedRegistration);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.RegistrationData().Delete(id);
        }
    }
}

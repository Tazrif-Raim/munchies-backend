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
    public class DeliveryBoyProfileService
    {
        public static void Create(DeliveryBoyProfileDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DeliveryBoyProfileDTO, DeliveryBoyProfile>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<DeliveryBoyProfile>(s);
            DataAccessFactory.DeliveryBoyProfileData().Create(cnv);
        }
        public static DeliveryBoyProfileDTO Get(int id)
        {

            var data = DataAccessFactory.DeliveryBoyProfileData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DeliveryBoyProfile, DeliveryBoyProfileDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<DeliveryBoyProfileDTO>(data);
        }
        public static List<DeliveryBoyProfileDTO> Get()
        {
            var data = DataAccessFactory.DeliveryBoyProfileData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DeliveryBoyProfile, DeliveryBoyProfileDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<DeliveryBoyProfileDTO>>(data);

        }
        public static void Update(int id, DeliveryBoyProfileDTO UpdateDeliveryBoyProfile)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeliveryBoyProfileDTO, DeliveryBoyProfile>();
            });
            var mapper = new Mapper(config);
            var updatedDeliveryBoyProfileEntity = mapper.Map<DeliveryBoyProfile>(UpdateDeliveryBoyProfile);
            updatedDeliveryBoyProfileEntity.Id = id; // Ensure the ID is set for the correct meal to update
            DataAccessFactory.DeliveryBoyProfileData().Update(updatedDeliveryBoyProfileEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.DeliveryBoyProfileData().Delete(id);
        }

    }
}

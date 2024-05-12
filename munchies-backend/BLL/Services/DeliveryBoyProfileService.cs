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

    }
}

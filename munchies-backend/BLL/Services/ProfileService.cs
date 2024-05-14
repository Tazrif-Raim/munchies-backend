using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL.Repos;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfileService
    {
        public static void Create(ProfileDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProfileDTO, DAL.Models.Profile>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<DAL.Models.Profile>(s);
            DataAccessFactory.ProfileData().Create(cnv);
        }
        public static ProfileDTO Get(int id)
        {

            var data = DataAccessFactory.ProfileData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.Models.Profile, ProfileDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ProfileDTO>(data);
        }
        public static List<ProfileDTO> Get()
        {
            var data = DataAccessFactory.ProfileData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.Models.Profile, ProfileDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ProfileDTO>>(data);

        }
        public static void Update(int id, ProfileDTO updatedProfile)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileDTO, DAL.Models.Profile>();
            });
            var mapper = new Mapper(config);
            var updatedProfileEntity = mapper.Map<DAL.Models.Profile>(updatedProfile);
            updatedProfileEntity.Id = id; // Ensure the ID is set for the correct meal to update
            DataAccessFactory.ProfileData().Update(updatedProfileEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.ProfileData().Delete(id);
        }
    }
}

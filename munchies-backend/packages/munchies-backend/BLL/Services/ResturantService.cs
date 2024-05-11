using AutoMapper;
using BAL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ResturantService
    {
        public static List<ResturantDTO> Get() { 
        var data = DataAccessFactory.ResturantData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Resturant, ResturantDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ResturantDTO>>(data);
            return mapped;
        }
        public static ResturantDTO Get(int id) {
        var data = DataAccessFactory.ResturantData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Resturant, ResturantDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ResturantDTO>(data);
            return mapped;
        }
    }
}

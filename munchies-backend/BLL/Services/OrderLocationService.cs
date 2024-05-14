using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderLocationService
    {
        public static void Create(OrderLocationDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderLocationDTO, OrderLocation>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<OrderLocation>(s);
            DataAccessFactory.OrderLocationData().Create(cnv);
        }
        public static OrderLocationDTO Get(int id)
        {

            var data = DataAccessFactory.OrderLocationData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderLocation, OrderLocationDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<OrderLocationDTO>(data);
        }
        public static List<OrderLocationDTO> Get()
        {
            var data = DataAccessFactory.OrderLocationData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderLocation, OrderLocationDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderLocationDTO>>(data);

        }

        public static void Update(int id, OrderLocationDTO updatedOrderLocation)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderLocationDTO, OrderLocation>();
            });
            var mapper = new Mapper(config);
            var updatedOrderLocationEntity = mapper.Map<OrderLocation>(updatedOrderLocation);
            updatedOrderLocationEntity.Id = id; // Ensure the ID is set for the correct meal to update
            DataAccessFactory.OrderLocationData().Update(updatedOrderLocationEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.OrderLocationData().Delete(id);
        }

    }
}

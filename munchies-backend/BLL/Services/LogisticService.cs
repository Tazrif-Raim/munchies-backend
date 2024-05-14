using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LogisticService
    {
        public static void Create(LogisticDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LogisticDTO, Logistic>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Logistic>(s);
            DataAccessFactory.logisticData().Create(cnv);
        }
        public static LogisticDTO Get(int id)
        {

            var data = DataAccessFactory.logisticData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Logistic, LogisticDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<LogisticDTO>(data);
        }
        public static List<LogisticDTO> Get()
        {
            var data = DataAccessFactory.logisticData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Logistic, LogisticDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<LogisticDTO>>(data);

        }
        public static void Update(int id, LogisticDTO updatedlogistic)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LogisticDTO, Logistic>();
            });
            var mapper = new Mapper(config);
            var updatedlogisticEntity = mapper.Map<Logistic>(updatedlogistic);
            updatedlogisticEntity.Id = id;
            // Ensure the ID is set for the correct logistic to update
            DataAccessFactory.logisticData().Update(updatedlogisticEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.logisticData().Delete(id);
        }
    }
}


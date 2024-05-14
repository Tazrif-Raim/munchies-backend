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
    public class ChangeMobileBankingNumberService
    {
        public static void Create(ChangeMobileBankingNumberDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ChangeMobileBankingNumber, ChangeMobileBankingNumber>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<ChangeMobileBankingNumber>(s);
            DataAccessFactory.ChangeMobileBankingNumberData().Create(cnv);
        }
        public static ChangeMobileBankingNumberDTO Get(int id)
        {

            var data = DataAccessFactory.ChangeMobileBankingNumberData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ChangeMobileBankingNumber, ChangeMobileBankingNumberDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ChangeMobileBankingNumberDTO>(data);
        }
        public static List<ChangeMobileBankingNumberDTO> Get()
        {
            var data = DataAccessFactory.ChangeMobileBankingNumberData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ChangeMobileBankingNumber, ChangeMobileBankingNumberDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ChangeMobileBankingNumberDTO>>(data);

        }
        public static void Update(int id, ChangeMobileBankingNumberDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChangeMobileBankingNumberDTO, ChangeMobileBankingNumber>();
            });
            var mapper = new Mapper(config);
            var updatedChangeMobileBankingNumber = mapper.Map<ChangeMobileBankingNumber>(s);
            updatedChangeMobileBankingNumber.Id = id;
            DataAccessFactory.ChangeMobileBankingNumberData().Update(updatedChangeMobileBankingNumber);
        }
    }
}

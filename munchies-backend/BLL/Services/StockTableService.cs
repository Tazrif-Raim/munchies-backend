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
    public class StockTableService
    {
        public static void Create(StockTableDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StockTableDTO, StockTable>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<StockTable>(s);
            DataAccessFactory.StockTableData().Create(cnv);
        }
        public static StockTableDTO Get(int id)
        {

            var data = DataAccessFactory.StockTableData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StockTable, StockTableDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<StockTableDTO>(data);
        }
        public static List<StockTableDTO> Get()
        {
            var data = DataAccessFactory.StockTableData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StockTable, StockTableDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<StockTableDTO>>(data);

        }
        public static void Update(int id, StockTableDTO updatedStock)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StockTableDTO, StockTable>();
            });
            var mapper = new Mapper(config);
            var updatedStockEntity = mapper.Map<StockTable>(updatedStock);
            updatedStockEntity.Id = id;
            // Ensure the ID is set for the correct Stock to update
            DataAccessFactory.StockTableData().Update(updatedStockEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.StockTableData().Delete(id);
        }
    }
}

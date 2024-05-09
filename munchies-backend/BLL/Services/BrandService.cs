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
    public class BrandService
    {
        public static List<BrandDTO> GetAllBrands()
        {
            var data = DataAccessFactory.BrandData().Read();
            List<BrandDTO> brands = new List<BrandDTO>();
            foreach (var item in data)
            {
                BrandDTO brand = new BrandDTO();
                brand.Id = item.Id;
                brand.Name = item.Name;
                brand.style = item.style;
                brands.Add(brand);
            }
            return brands;
        }

        public static BrandDTO getBrandInfo(Guid id)
        {
            var data = DataAccessFactory.BrandData().Read(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Brand, BrandDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BrandDTO>(data);

            return mapped;
        }
    }
}

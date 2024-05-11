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

        public static BrandRecipeDTO getBrandInfo(Guid id)
        {
            var data = DataAccessFactory.BrandData().Read(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Brand, BrandDTO>();
                c.CreateMap<Brand, BrandRecipeDTO>();
                c.CreateMap<Recipe, RecipeDTO>();
                c.CreateMap<Ingredient, IngredientDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BrandRecipeDTO>(data);

            return mapped;
        }

        public static void setBrand(BrandDTO brand)
        {
            brand.Id = Guid.NewGuid();
            
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BrandDTO, Brand>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Brand>(brand);

            DataAccessFactory.BrandData().Create(mapped);
        }

        public static void setBrandRecipe(BrandRecipeDTO brandRecipe)
        {
            if(brandRecipe.Id == Guid.Empty || brandRecipe.Id == null)
            {
                brandRecipe.Id = Guid.NewGuid();
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BrandRecipeDTO, Brand>();
                c.CreateMap<RecipeDTO, Recipe>();
                c.CreateMap<IngredientDTO, Ingredient>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Brand>(brandRecipe);

            DataAccessFactory.BrandData().Update(mapped);
        }
    }
}

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
    public class RecipeService
    {
        public static void setRecipe(RecipeDTO recipe)
        {
            recipe.Id = Guid.NewGuid();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<RecipeDTO, Recipe>();
                c.CreateMap<IngredientDTO, Ingredient>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Recipe>(recipe);
            DataAccessFactory.RecipeData().Create(mapped);
        }
    }
}

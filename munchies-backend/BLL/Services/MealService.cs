using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MealService
    {
        /*public static object Get()
        {
           return MealRepo.Get();
        }
        public static Meal Get(int id)
        {
            return MealRepo.Get(id);
        }
        public static bool Create(Meal meal)
        {
            return MealRepo.Create(meal);
        }
        public static bool Update(Meal meal)
        {
            return MealRepo.Update(meal);
        }
        public static bool Delete(int id)
        {
            return MealRepo.Delete(id);
        }*/

        public static void Create(MealDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MealDTO, Meal>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Meal>(s);
            DataAccessFactory.MealData().Create(cnv);
        }
        public static MealDTO Get(int id)
        {

            var data = DataAccessFactory.MealData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Meal, MealDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<MealDTO>(data);
        }
        public static List<MealDTO> Get()
        {
            var data = DataAccessFactory.MealData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Meal, MealDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<MealDTO>>(data);

        }
        public static void Update(int id, MealDTO updatedMeal)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MealDTO, Meal>();
            });
            var mapper = new Mapper(config);
            var updatedMealEntity = mapper.Map<Meal>(updatedMeal);
            updatedMealEntity.Id = id; // Ensure the ID is set for the correct meal to update
            DataAccessFactory.MealData().Update(updatedMealEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.MealData().Delete(id);
        }
    }
}

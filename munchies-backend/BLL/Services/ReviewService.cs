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
    public class ReviewService
    {
        public static void Create(ReviewDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReviewDTO, Review>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Review>(s);
            DataAccessFactory.ReviewData().Create(cnv);
        }
        public static ReviewDTO Get(int id)
        {

            var data = DataAccessFactory.ReviewData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ReviewDTO>(data);
        }
        public static List<ReviewDTO> Get()
        {
            var data = DataAccessFactory.ReviewData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ReviewDTO>>(data);

        }

        public static void Update(int id, ReviewDTO updatedReview)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewDTO, Review>();
            });
            var mapper = new Mapper(config);
            var updatedReviewEntity = mapper.Map<Review>(updatedReview);
            updatedReviewEntity.Id = id; // Ensure the ID is set for the correct meal to update
            DataAccessFactory.ReviewData().Update(updatedReviewEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.ReviewData().Delete(id);
        }
    }
}

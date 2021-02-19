using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EfCarTableContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (EfCarTableContext context = new EfCarTableContext())
            {
                var result = from ca in filter is null ? context.Car : context.Car.Where(filter)
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join co in context.Color
                             on ca.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandId = br.Id,
                                 ColorId = co.Id,
                                 BrandName = br.Name,
                                 Name = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}

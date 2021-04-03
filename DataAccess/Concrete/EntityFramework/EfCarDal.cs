using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
                var result = from ca in filter is null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                             on ca.brandId equals br.BrandId
                             join co in context.Colors
                             on ca.colorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = ca.carId,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.dailyPrice,
                                 Description = ca.description,
                                 ModelYear = ca.modelYear
                             };
                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetailDto(Expression<Func<Car, bool>> filter = null)
        {
            using (EfCarTableContext context = new EfCarTableContext())
            {
                var result = from ca in filter is null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                             on ca.brandId equals br.BrandId
                             join co in context.Colors
                             on ca.colorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = ca.carId,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.dailyPrice,
                                 Description = ca.description,
                                 ModelYear = ca.modelYear
                             };
                return result.SingleOrDefault() ;
            }
        }
    }
}

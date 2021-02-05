using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramwork;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandDal = new BrandManager(new EfBrandDal());

            foreach (var car in brandDal.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Name);
            }
            brandDal.Add(new Brand { Id = 6, Name = "ab" });




            ColorManager colorDal = new ColorManager(new EfColorDal());

            foreach (var car in colorDal.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Name);
            }


            CarManager carDal = new CarManager(new EfCarDal());
            carDal.Add(new Car { BrandId = 9, ColorId = 009, DailyPrice = 10, Description = "6.iyi", ModelYear = 2021 });

        }
    }
}

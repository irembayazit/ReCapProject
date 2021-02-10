using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramwork;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static CarManager _carService = new CarManager(new EfCarDal());
        static void Main(string[] args)
        {
            GetAll();
            Console.WriteLine(Environment.NewLine);
            GetCarsByBrandId();
            Console.WriteLine(Environment.NewLine);
            GetCarsByColorId();
            Console.WriteLine(Environment.NewLine);
            Add();
        }
        static void Add()
        {
            try
            {
                Car car = new Car
                {
                    BrandId = 7,
                    ColorId = 9,
                    DailyPrice = 0,
                    Description = "Yeni Araç",
                    ModelYear = 2015,
                };
                _carService.Add(car);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        static void GetCarsByBrandId()
        {
            List<CarDetailDto> cars = _carService.GetCarsByBrandId(4);
            foreach (var car in cars)
            {
                Console.WriteLine(String.Format($"Id : {car.Id}, Name : {car.Description}, BrandId : {car.BrandId}"));
            }
        }

        static void GetCarsByColorId()
        {
            List<CarDetailDto> cars = _carService.GetCarsByColorId(3);
            foreach (var car in cars)
            {
                Console.WriteLine(String.Format($"Id : {car.Id}, Name : {car.Description}, ColorId : {car.ColorId}"));
            }
        }
         
        static void GetAll()
        {
            foreach (Car car in _carService.GetAll())
            {
                Console.WriteLine(String.Format($"Id : {car.Id}, Name : {car.Description}"));
            }
        }

        private static void ilkDeneme()
        {
            BrandManager brandDal = new BrandManager(new EfBrandDal());

            foreach (var car in brandDal.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Name);
            }
            brandDal.Add(new Brand { Id = 7, Name = "cd" });




            ColorManager colorDal = new ColorManager(new EfColorDal());

            foreach (var car in colorDal.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Name);
            }


            CarManager carDal = new CarManager(new EfCarDal());
            carDal.Add(new Car { BrandId = 9, ColorId = 009, DailyPrice = 10, Description = "6.iyi", ModelYear = 2021 });
            //carDal.Delete(new Car { BrandId = 9, ColorId = 009, DailyPrice = 10, Description = "6.iyi", ModelYear = 2021 });


            Console.WriteLine("********************************");

            CarTableContext carTableContext = new CarTableContext();
            foreach (var item in carTableContext.Car)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}

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
            //Fonk_deneme();
            CarManager productManager = new CarManager(new EfCarDal());

            var result = productManager.GetCarDetailDto();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void Fonk_deneme()
        {
            GetAll();
            Console.WriteLine(Environment.NewLine);

            GetCarsByBrandId();
            Console.WriteLine(Environment.NewLine);

            GetCarsByColorId();
            Console.WriteLine(Environment.NewLine);

            Add();
            GetAll();

            Console.WriteLine(Environment.NewLine);
            //_carService.Delete(new Car { Id = 2 });
            //GetAll();
            //Console.WriteLine(Environment.NewLine);

            _carService.Update(new Car { Id = 1015, DailyPrice = 100, Description = " degistirilen arac" });
            GetAll();
            Console.WriteLine(Environment.NewLine);

            var cars = _carService.GetCarDetailDto();

            foreach (var car in cars.Data)
            {
                Console.WriteLine(car.Name + "---" + car.BrandName + "---" + car.ColorName + "---" + car.DailyPrice);
            }
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
            var cars = _carService.GetCarsByBrandId(4);
            foreach (var car in cars.Data)
            {
                Console.WriteLine(String.Format($"Id : {car.Id}, Name : {car.Name}, BrandId : {car.BrandId}"));
            }
        }

        static void GetCarsByColorId()
        {
            var cars = _carService.GetCarsByColorId(3);

            foreach (var car in cars.Data)
            {
                Console.WriteLine(String.Format($"Id : {car.Id}, Name : {car.Description}, ColorId : {car.ColorId}"));
            }
        }
         
        static void GetAll()
        {
            var result3 = _carService.GetAll();
            foreach (Car car in result3.Data)
            {
                Console.WriteLine(String.Format($"Id : {car.Id}, Name : {car.Description}"));
            }
        }

        private static void ilkDeneme()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetCarsByBrandId(2);

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Name);
            }
            brandManager.Add(new Brand { Id = 7, Name = "cd" });




            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result2 = colorManager.GetCarsByColorId(3);
            
            foreach (var car in result2.Data)
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

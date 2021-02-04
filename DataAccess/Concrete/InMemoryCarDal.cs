using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=003,DailyPrice=700,ModelYear=2019,Description="1.Well"},
                new Car{Id=2,BrandId=2,ColorId=005,DailyPrice=500,ModelYear=2018,Description="2.Well"},
                new Car{Id=3,BrandId=1,ColorId=002,DailyPrice=1000,ModelYear=2020,Description="3.Well"},
                new Car{Id=4,BrandId=1,ColorId=003,DailyPrice=800,ModelYear=2016,Description="4.Well"},
                new Car{Id=5,BrandId=2,ColorId=008,DailyPrice=600,ModelYear=2015,Description="5.Well"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(p=>p.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
    }
}

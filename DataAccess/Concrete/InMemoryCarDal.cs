using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{CarId=1,BrandId=1,ColorId=003,DailyPrice=700,ModelYear=2019,Description="1.Well"},
                new Car{CarId=2,BrandId=2,ColorId=005,DailyPrice=500,ModelYear=2018,Description="2.Well"},
                new Car{CarId=3,BrandId=1,ColorId=002,DailyPrice=1000,ModelYear=2020,Description="3.Well"},
                new Car{CarId=4,BrandId=1,ColorId=003,DailyPrice=800,ModelYear=2016,Description="4.Well"},
                new Car{CarId=5,BrandId=2,ColorId=008,DailyPrice=600,ModelYear=2015,Description="5.Well"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(p=>p.CarId == car.CarId);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
    }
}

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
                new Car{Id=1,brandId=1,colorId=003,dailyPrice=700,modelYear=2019,description="1.Well"},
                new Car{Id=2,brandId=2,colorId=005,dailyPrice=500,modelYear=2018,description="2.Well"},
                new Car{Id=3,brandId=1,colorId=002,dailyPrice=1000,modelYear=2020,description="3.Well"},
                new Car{Id=4,brandId=1,colorId=003,dailyPrice=800,modelYear=2016,description="4.Well"},
                new Car{Id=5,brandId=2,colorId=008,dailyPrice=600,modelYear=2015,description="5.Well"}
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
            Car carUpdate = _cars.SingleOrDefault(p=>p.Id == car.Id);
            carUpdate.brandId = car.brandId;
            carUpdate.colorId = car.colorId;
            carUpdate.dailyPrice = car.dailyPrice;
            carUpdate.description = car.description;
        }

        public CarDetailDto GetCarDetailDto(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarFilterBrandIdColorId(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }
    }
}

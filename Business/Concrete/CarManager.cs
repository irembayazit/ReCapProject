using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine($"Lütfen günlük fiyat kısmını 0'dan büyük giriniz. Girdiğiniz değer : {car.DailyPrice}");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            return _carDal.GetCarDetailDtos();
        }

        public List<CarDetailDto> GetCarsByBrandId(int v)
        {
            return _carDal.GetCarDetailDtos(x=> x.BrandId == v);
        }

        public List<CarDetailDto> GetCarsByColorId(int v)
        {
            return _carDal.GetCarDetailDtos(x => x.ColorId == v);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<CarDetailDto> GetCarsByBrandId(int v);
        List<CarDetailDto> GetCarsByColorId(int v);
        List<CarDetailDto> GetCarDetailDto(int v);

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}

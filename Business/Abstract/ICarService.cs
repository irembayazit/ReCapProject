using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int v);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int v);
        IDataResult<Car> GetCarById(int v);
        IDataResult<List<CarDetailDto>> GetCarDetailDto();
        IDataResult<CarDetailDto> GetCarDetailDtoByCarId(int carId);

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId);
        IResult AddTransactionTest(Car car);
    }
}

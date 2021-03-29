using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constent;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carImageService = carImageService;
            _carDal = carDal;
        }

        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //business code

            _carDal.Add(car);

            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("product.delete,manager")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId)
        {
            var result = _carDal.GetCarDetailDtos(x => x.id == carId).SingleOrDefault();

            var imageResult = _carImageService.GetImagesByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarDetailAndImagesDto>(Messages.GetErrorCarMessage);
            }

            var carDetailAndImagesDto = new CarDetailAndImagesDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarDetailAndImagesDto>(carDetailAndImagesDto, Messages.GetSuccessCarMessage);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }

        public IDataResult<CarDetailDto> GetCarDetailDtoByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailDto(x=>x.id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            IResult result = BusinessRules.Run(CheckIfBrandId(brandId));

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(x=> x.brandId == brandId));
        }


        private IResult CheckIfBrandId(int brandId)
        {
            var result = _carDal.GetAll(p => p.brandId == brandId).Any();
            if (result)
            {
                return new ErrorResult(Messages.BradndIdNotFound);
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int v)
        {
            return new  SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(x => x.colorId == v));
        }

        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Car> GetCarById(int v)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.id == v));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);
            if (car.dailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }

    }
}

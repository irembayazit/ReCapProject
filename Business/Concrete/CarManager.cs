using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constent;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
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

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //business code

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("product.delete,manager")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
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

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int v)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(x=> x.BrandId == v));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int v)
        {
            return new  SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(x => x.ColorId == v));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetCarById(int v)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == v));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }
    }
}

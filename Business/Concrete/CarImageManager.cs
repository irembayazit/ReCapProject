using Business.Abstract;
using Business.Constent;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImageDto carImageDto)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceded(carImageDto.CarId));
            
            if (result != null)
            {
                return result;
            }
            CarImage carImage = new CarImage
            {
                CarId = carImageDto.CarId,
                ImagePath = FileHelper.UploadImageFile(carImageDto.ImageFile),
                Date = DateTime.Now
            };
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.ImagesAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImageDto carImageDto)
        {
            var dbImage = _carImageDal.Get(ci => ci.id == carImageDto.Id);
            if (dbImage == null) return new ErrorResult("Image nor found");
            FileHelper.UpdateImageFile(carImageDto.ImageFile, dbImage.ImagePath);
            return new SuccessResult(Messages.ImagesAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p=>p.id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
            }
            return new ErrorDataResult<List<CarImage>>(Messages.CarIdNotFound);
        }

        private IResult CheckIfImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }
            return new SuccessResult(Messages.ImagesAdded);
        }
        private IResult CheckIfIdControl(int carId)
        {
            var result = _carImageDal.GetAll(x=>x.CarId == carId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarIdNotFound);
            }
            return new SuccessResult(Messages.ImagesAdded);
        }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            var path = @"\Images\logo.jpg";

            var result = _carImageDal.GetAll(p => p.CarId == id).Any();

            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
           
        }

    }
}

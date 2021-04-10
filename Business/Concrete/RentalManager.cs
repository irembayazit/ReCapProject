using Business.Abstract;
using Business.Constent;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerDal _customerDal;
        public RentalManager(IRentalDal rentalDal, ICustomerDal customerDal)
        {
            _rentalDal = rentalDal;
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.UserFindex(x => x.Id == rental.CustomerId);
            var result2 = _rentalDal.CardFindex(x => x.CarId == rental.CarId);

            if (result.Data > result2.Data)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdd);
            }
            else
            {
                return new ErrorResult(Messages.NotFindex);
            }
        }


        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetRentalByCarId(int carId)
        {
            var result = _rentalDal.Get(x => x.CarId == carId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(result, Messages.RentalListed);
            }
            else
            {
                return new ErrorDataResult<Rental>(Messages.CarIdNotFound);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalByCarIdDetailDTOs(int carId)
        {
            var result = _rentalDal.GetRentalDetailDTOs(x => x.CarId == carId);
            if(result.Count!=0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(result,Messages.RentalListed);
            }
            else
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.CarIdNotFound);
            }
            
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDTOs()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDTOs(), Messages.RentalListed);
        }

        public IResult IsRentable(Rental rental)
        {
            var dates = _rentalDal.GetAll(x => x.CarId == rental.CarId);
            foreach (var date in dates)
            {
                if (date.RentDate <= rental.RentDate && rental.RentDate <= date.ReturnDate)
                {
                    return new ErrorResult(Messages.NotRental);
                }
                else if (date.RentDate <= rental.ReturnDate && rental.ReturnDate <= date.ReturnDate)
                {
                    return new ErrorResult(Messages.NotRental);
                }
                else if (date.RentDate >= rental.RentDate && rental.ReturnDate >= date.ReturnDate)
                {
                    return new ErrorResult(Messages.NotRental);
                }
            }
             return new SuccessResult();
            
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}

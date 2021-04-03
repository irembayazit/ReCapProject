using Business.Abstract;
using Business.Constent;
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
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if(rental.CustomerId == 0 )
            {
                return new ErrorResult(Messages.RentalNotAdd);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdd);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
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
                    return new ErrorResult();
                }
                else if (date.RentDate <= rental.ReturnDate && rental.ReturnDate <= date.ReturnDate)
                {
                    return new ErrorResult();
                }
                else if (date.RentDate >= rental.RentDate && rental.ReturnDate >= date.ReturnDate)
                {
                    return new ErrorResult();
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

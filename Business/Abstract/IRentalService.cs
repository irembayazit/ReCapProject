using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetailDTOs();
        IDataResult<List<RentalDetailDto>> GetRentalByCarIdDetailDTOs(int carId);
        IDataResult<Rental> GetRentalByCarId(int carId);
        IResult IsRentable(Rental rental);
    }
}

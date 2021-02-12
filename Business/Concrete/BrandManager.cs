using Business.Abstract;
using Business.Constent;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length >= 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarAddInvalid);
            }
        }

        public IDataResult<List<Brand>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.Id == id));
        }
    }
}

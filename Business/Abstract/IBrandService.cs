using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetCarsByBrandId(int brandId);
        IResult Add(Brand name);
        IResult Update(Brand name);
        IDataResult<List<Brand>> GetAll();
    }
}

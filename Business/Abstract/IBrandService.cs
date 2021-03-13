﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetCarsByBrandId(int id);
        IResult Add(Brand name);
        IDataResult<List<Brand>> GetAll();
    }
}

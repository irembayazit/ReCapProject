﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetailDto(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetCarFilterBrandIdColorId(int brandId, int colorId);
    }
}

using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal: IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetailDTOs(Expression<Func<Rental, bool>> filter = null);

    }
}

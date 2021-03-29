using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<Color> GetCarsByColorId(int id);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Update(Color color);
    }
}

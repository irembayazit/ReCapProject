using Business.Abstract;
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

        public void Add(Brand brand)
        {
            if (brand.Name.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine($"Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz. Girdiğiniz marka ismi : {brand.Name}");
            }
        }

        public List<Brand> GetCarsByBrandId(int id)
        {
            return _brandDal.GetAll(p => p.Id == id);
        }
    }
}

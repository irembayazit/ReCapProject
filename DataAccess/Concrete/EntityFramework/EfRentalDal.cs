using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,EfCarTableContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDTOs()
        {
            using (var context = new EfCarTableContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             
                             select new RentalDetailDto { RentalId = rental.Id, BrandName = brand.Name, CustomerName = user.FirstName + " " +  user.LastName, RentDate = rental.RentDate , ReturnDate = rental.ReturnDate };

                return result.ToList();
            }
        }

       
    }
}

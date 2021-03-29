using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results.Abstract;
using System.Linq.Expressions;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,EfCarTableContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDTOs(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context = new EfCarTableContext())
            {
                
                var result = from rental in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.id
                             join brand in context.Brands on car.brandId equals brand.BrandId
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             
                             select new RentalDetailDto { RentalId = rental.Id, BrandName = brand.Name, CustomerName = user.FirstName + " " +  user.LastName, RentDate = rental.RentDate , ReturnDate = rental.ReturnDate };

                return result.ToList();
            }
        }
    }
}

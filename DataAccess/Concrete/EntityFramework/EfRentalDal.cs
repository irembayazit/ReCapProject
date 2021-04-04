using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,EfCarTableContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDTOs(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context = new EfCarTableContext())
            {
                
                var result = from rental in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.brandId equals brand.BrandId
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             
                             select new RentalDetailDto { RentalId = rental.Id, BrandName = brand.Name, CustomerName = user.FirstName + " " +  user.LastName, RentDate = rental.RentDate , ReturnDate = rental.ReturnDate };

                return result.ToList();
            }
        }


        public IDataResult<int> UserFindex(Expression<Func<Customer, bool>> filterUser = null)
        {
            using (var context = new EfCarTableContext())
            {

                var userFindex = from customer in filterUser is null ? context.Customers : context.Customers.Where(filterUser)
                                 join user in context.Users on customer.UserId equals user.Id
                                 select user.Findex;

                return new SuccessDataResult<int>(userFindex.FirstOrDefault());
            }
        }

        public IDataResult<int> CardFindex(Expression<Func<Rental, bool>> filterCard = null)
        {
            using (var context = new EfCarTableContext())
            {

                var cardFindex = from rental in filterCard is null ? context.Rentals : context.Rentals.Where(filterCard)
                                 join car in context.Cars on rental.CarId equals car.Id
                                 select car.Findex;

                return new SuccessDataResult<int>(cardFindex.FirstOrDefault());
            }
        }

    }
}

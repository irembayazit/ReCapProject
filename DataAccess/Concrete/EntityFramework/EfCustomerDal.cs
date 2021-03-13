using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, EfCarTableContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDTOs()
        {
            using (var context = new EfCarTableContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             select new CustomerDetailDto { CustomerId = c.Id, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName };

                return result.ToList();
            }
        }
    }
}

using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, EfCarTableContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EfCarTableContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }


        public UserDto GetUserByEmail(string email)
        {
            using (var context = new EfCarTableContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers on user.Id equals customer.UserId
                             where user.Email.Trim().Equals(email)
                             select new UserDto{FirstName = user.FirstName, LastName = user.LastName, CustomerId = customer.Id};

                return result.FirstOrDefault();
            }
        }

    }
}
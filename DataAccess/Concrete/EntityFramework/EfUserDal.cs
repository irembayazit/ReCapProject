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
        public List<string> GetAuthority(Expression<Func<User, bool>> filter = null)
        {
            using (EfCarTableContext context = new EfCarTableContext())
            {
                var result  = from user in filter is null ? context.Users : context.Users.Where(filter)
                             join operation in context.UserOperationClaims on user.Id equals operation.UserId
                             join operationClaim in context.OperationClaims on operation.OperationClaimId equals operationClaim.Id
                             select new List<string>
                             {
                                 operationClaim.Name
                             };
                return (List<string>)result;
            }
        }

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
                             select new UserDto { CustomerId = customer.Id, UserId = user.Id,FirstName = user.FirstName, LastName = user.LastName , CompanyName=customer.CompanyName , Findex=user.Findex};

                return result.FirstOrDefault();
            }
        }

    }
}

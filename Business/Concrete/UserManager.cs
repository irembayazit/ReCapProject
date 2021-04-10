 using Business.Abstract;
using Business.Constent;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using Core.Utilities.Security.Hasing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ICustomerDal _customerDal;
        public UserManager(IUserDal userDal, ICustomerDal customerDal)
        {
            _userDal = userDal;
            _customerDal = customerDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdd);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDelete);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserDelete);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), "Roller geldi");
        }

        public IDataResult<UserDto> GetUserByEmail(string email)
        {
            var result = _userDal.GetUserByEmail(email);
            if (result != null)
            {
                return new SuccessDataResult<UserDto>(result);
            }

            return new ErrorDataResult<UserDto>("Böyle bir kullanıcı bulunamadı");
        }

        public IResult UserDtoUpdate(UpdateUserDto updateUserDto)
        {
            var user = GetById(updateUserDto.Id).Data;

            if(updateUserDto.CurrentPassword != "" && updateUserDto.NewPassword != "")
            {
                if (!HashingHelper.VerifyPasswordHash(updateUserDto.CurrentPassword, user.PasswordHash, user.PasswordSalt))
                {
                    return new ErrorResult(Messages.PasswordError);
                }
                    
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(updateUserDto.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                
            }
            
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Email = updateUserDto.Email;

            _userDal.Update(user);

            var customer = _customerDal.Get(c => c.Id == updateUserDto.CustomerId);
            customer.CompanyName = updateUserDto.CompanyName;
            _customerDal.Update(customer);

            return new SuccessResult(Messages.UserDetailsUpdated);
        }

        public IDataResult<List<string>> Authority(string email)
        {
            return new SuccessDataResult<List<string>>(_userDal.GetAuthority(x=>x.Email == email));
        }
    }
}

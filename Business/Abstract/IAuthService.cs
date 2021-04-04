﻿using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Entities.DTOs.Concrete;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<UserDto> GetUserByEmail(string email);
    }
}

using PXLFunds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Services
{
    public interface IUserLoginRepository
    {
        UserLoginResult Register(RegisterModel register);
        UserLoginResult Login(LoginModel login);
    }
}

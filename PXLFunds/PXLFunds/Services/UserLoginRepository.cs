using Microsoft.AspNetCore.Identity;
using PXLFunds.Data;
using PXLFunds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Services
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly ApplicationDbContext _context;
        public UserLoginRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public UserLoginResult Register(RegisterModel register)
        {
            return Register(register.UserName, register.Email, register.Password);
        }
        public UserLoginResult Register(string userName, string email, string password)
        {
            var result = new UserLoginResult();
            var user = new IdentityUser { UserName = userName, Email = email };
            var registerresult = _userManager.CreateAsync(user, password);
            if (registerresult.Result.Succeeded)
            {
                result.Succeeded = true;
            }
            else
            {
                result.Error = "error while trying to register this user!";
            }
            return result;
        }
        public UserLoginResult Login(LoginModel login)
        {
            return Login(login.Email, login.Password);
        }
        public UserLoginResult Login(string email, string password)
        {
                    var result = new UserLoginResult();
            var user = getidentityuser(email);
            if (user != null)
            {
                var loginResult = _signinManager.PasswordSignInAsync(user, password, false, lockoutOnFailure: false);
                if (loginResult.Result.Succeeded)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Error = "Passwordwas not correct for this user!";
                }
            }
            else
            {
                result.Error = "No user found for this email address!";
            }
            return result;
        }
        private IdentityUser getidentityuser(string email)
        {
            IdentityUser user = null;
            user = _userManager.FindByEmailAsync(email).Result;
            return user;
        }
        public SignOutResult signout()
        {
            var result = new SignOutResult();
            try
            {
                _signinManager.SignOutAsync();
                result.Succeeded = true;
            }
            catch
            { }
            return result;
        }
    }
    public class SignOutResult
    {
        public bool Succeeded { get; set; }
    }
    public class UserLoginResult
    {
        public bool Succeeded { get; set; }
        public string Error { get; set; }
    }
}

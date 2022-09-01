using Microsoft.AspNetCore.Mvc;
using PXLFunds.Models;
using PXLFunds.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Controllers
{
    public class AccountController : Controller
    {
        IUserLoginRepository _loginRepo;
        public AccountController(IUserLoginRepository loginRepo)
        {
            _loginRepo = loginRepo;
        }
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var result = _loginRepo.Login(login);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = _loginRepo.Register(registerModel);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion
        public IActionResult Logout()
        {
            //_loginRepo.Signout();
            return RedirectToAction("Index", "Home");
        }
        #region External login
        //public IActionResult ExternalLogin()
        //{
        //    //determine url to which external provider should send the authentication result response
        //    string redirectUrl = Url.Action("ExternalLoginResponse", "Account");

        //    //send a challenge result which will make the client (browser) redirect to the login page of google
        //    AuthenticationProperties properties =
        //        _signInManager.ConfigureExternalAuthenticationProperties(OpenIdConnectDefaults.AuthenticationScheme, redirectUrl);
        //    return new ChallengeResult(OpenIdConnectDefaults.AuthenticationScheme, properties);
        //}
        //public async Task<IActionResult> ExternalLoginResponse()
        //{
        //    //retrieve information that was send in the http request (by external provider)
        //    ExternalLoginInfo externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();

        //    if (externalLoginInfo == null)
        //    {
        //        //user did not login properly with external provider -> redirect to login page
        //        return RedirectToAction(nameof(Login));
        //    }

        //    //Retrieve info provided by external provider (claims)
        //    string email = externalLoginInfo.Principal.FindFirst("email").Value; //TODO: in opgave duidelijk maken dat de naam van de claim "email" is en niet ClaimTypes.Email 

        //    //try to sign in with external provider user id (ProviderKey)
        //    SignInResult result = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
        //        externalLoginInfo.ProviderKey, false);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    //Sign in failed -> user does not exist yet in our database

        //    //-> find user with same email
        //    IdentityUser user = await _userManager.FindByEmailAsync(email);
        //    if (user == null)
        //    {
        //        //not found -> create one
        //        user = new IdentityUser(email)
        //        {
        //            Email = email
        //        };
        //        await _userManager.CreateAsync(user);
        //    }

        //    //link the user to the external login info
        //    var identityResult = await _userManager.AddLoginAsync(user, externalLoginInfo);
        //    if (identityResult.Succeeded)
        //    {
        //        await _signInManager.SignInAsync(user, false);
        //        return RedirectToAction("Index", "Home");
        //    }

        //    throw new Exception("Something went wrong while linking the external login to a database user");
        //}
        #endregion
    }
}

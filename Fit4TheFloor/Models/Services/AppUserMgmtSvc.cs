using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Models.Interfaces;
using Fit4TheFloor.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Fit4TheFloor.Models.Services
{
    public class AppUserMgmtSvc : IAppUserManager
    {
        private UserManager<AppUser> _user;
        private SignInManager<AppUser> _signIn;

        public AppUserMgmtSvc(UserManager<AppUser> user, SignInManager<AppUser> signIn)
        {
            _user = user;
            _signIn = signIn;
        }

        public async Task<bool> Register(RegisterViewModel bag)
        {
            AppUser appUser = BuildUserFromRVM(bag);

        }

        public async Task<bool> Login(LoginViewModel bag)
        {
            if (ModelState.IsValid)
            {
                var query = await _signInManager.PasswordSignInAsync(bag.Email, bag.Password, false, false);

                if (query.Succeeded)
                {
                    return RedirectToRoute("");
                }

            }
            ModelState.AddModelError(string.Empty, "Login failed. Please try again.");

            return View("~/Views/Home/Index.cshtml");
        }

        public async Task<bool> Logout(string email)
        {

        }

        private AppUser BuildUserFromRVM(RegisterViewModel bag)
        {
            AppUser user = new AppUser()
            {
                UserName = bag.Email.ToLower(),
                Email = bag.Email.ToLower(),
                FirstName = bag.FirstName,
                LastName = bag.LastName,
                Birthdate = bag.Birthdate,
                PhoneNumber = bag.Phone,
                MailAddress = bag.MailAddress,
                MailCity = bag.MailCity,
                MailState = bag.MailState,
                MailZip = bag.MailZip,
            };
        }


        private AppUser BuildRVMFromUser(AppUser bag)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var query = await _user.CreateAsync(appUser, bag.Password);
            if (query.Succeeded)
            {
                // define and capture claims
                //Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                //Claim email = new Claim(ClaimTypes.Email, bag.Email, ClaimValueTypes.Email);

                // add all claims to DB
                //await _userManager.AddClaimsAsync(user, new List<Claim> { fullNameClaim, email });

                // apply user role(s)
                await _user.AddToRoleAsync(appUser, AppRoles.Customer);

                // send registration confirmation email
                Email message = new Email()
                {
                    Recipient = appUser.Email,
                    ConfigSet = "",
                    Subject = "Your Fit4theFloor user registration",
                    BodyHtml = @"<html>
                            <head></head>
                            <body>
                                <p>Your new account has been created.</p>
                                <p>Thank you for registering!</p>
                            </body>
                            </html>",
                };
                bool emailStatus = await message.Send();


                // sign in new user
                await _signIn.SignInAsync(appUser, isPersistent: false);
                return true;
            }
            return false;
        }

        public async Task<bool> Login(LoginViewModel bag)
        {
                var query = await _signIn.PasswordSignInAsync(bag.Email, bag.Password, false, false);

                if (query.Succeeded)
                {
                    return true;
                }

            return false;
        }

        public async Task Logout()
        {
            await _signIn.SignOutAsync();
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
            return user;
        }


        //private AppUser BuildRVMFromUser(AppUser bag)
        //{

        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Models.Interfaces;
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
    }
}

using Fit4TheFloor.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.Interfaces
{
    public interface IAppUserManager
    {

        Task<bool> Register(RegisterViewModel bag);
        Task<bool> Login(LoginViewModel bag);
        Task Logout();

    }
}

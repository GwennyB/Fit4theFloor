using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fit4TheFloor.Pages.Customer
{
    [Authorize(Roles = "Customer")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
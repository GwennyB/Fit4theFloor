using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;

namespace Fit4TheFloor.Models.Services
{
    public class PrintMgmtSvc : IPrintManager
    {
        private SalesDbContext _context { get; }

        public PrintMgmtSvc(SalesDbContext context)
        {
            _context = context;
        }

    }
}

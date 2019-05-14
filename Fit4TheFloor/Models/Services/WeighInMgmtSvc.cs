using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;

namespace Fit4TheFloor.Models.Services
{
    public class WeighInMgmtSvc : IWeighInManager
    {
        private StatsDbContext _context { get; }

        public WeighInMgmtSvc(StatsDbContext context)
        {
            _context = context;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;

namespace Fit4TheFloor.Models.Services
{
    public class PurchaseMgmtSvc : IPurchaseManager
    {
        private SalesDbContext _context { get; }

        public PurchaseMgmtSvc(SalesDbContext context)
        {
            _context = context;
        }


    }
}


﻿using CandyShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopApp.ViewModels
{
    public class CandyListViewModel
    {
        public IEnumerable<Candy> Candies { get; set; }
        public string CurrentCategory { get; set; }
    }
}

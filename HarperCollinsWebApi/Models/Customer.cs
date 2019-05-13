﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarperCollinsWebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
    }
}
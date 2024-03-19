﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public int Price { get; set; }
    }
}

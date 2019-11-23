﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.Entity
{
    public class User
    {
        public int ID { get; set; }
        public  string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Boolean IsAdmin { get; set; }
        public Address Address { get; set; }
        public DateTime LastActive { get; set; }
        public List<Order> Orders { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BMP.DataAccessLayer
{
    public class User
    {
        public  int UserId { get; set; }
        public string UserNameSurName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}

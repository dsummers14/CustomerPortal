﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerPortal
{
    public class UserViewModel
    {
     
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
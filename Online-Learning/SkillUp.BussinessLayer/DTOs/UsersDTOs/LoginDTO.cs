﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.UsersDTOs
{
    public class LoginDTO
    {
        public string Email { get; set; } 
        public string Password { get; set; } 
        public bool RememberMe { get; set; } = false;
    }
}

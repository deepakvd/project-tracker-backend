using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.DTOs.UserDtos
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        
    }
}

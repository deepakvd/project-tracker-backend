using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.DTOs.UserDtos
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}

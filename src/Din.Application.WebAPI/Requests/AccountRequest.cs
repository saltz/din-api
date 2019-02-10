﻿using Din.Domain.Models.Entity;
using Newtonsoft.Json;

namespace Din.Application.WebAPI.Requests
{
    public class AccountRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountRoll Role { get; set; }
    }
}

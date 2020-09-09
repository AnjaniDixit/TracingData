﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserDataAPI.DTO;
using UserDataAPI.Models;

namespace UserDataAPI.Controllers
{
    [ApiController]
    [Route("user/{id}")]
    public class UserDataController : ControllerBase
    {


        private readonly ILogger<UserDataController> _logger;
        private readonly UserDataContext _userDataContext;

        public UserDataController(ILogger<UserDataController> logger, UserDataContext userDataContext)
        {
            _logger = logger;
            _userDataContext = userDataContext;
        }

        [HttpGet]
        public User Get()
        {
            var data = _userDataContext.Users.FirstOrDefault(user => user.UserId == 1);
            return new User()
            {
                name = data.UserName,
                age = data.Age,
                email = data.UserEmail
            };
        }

    }
}

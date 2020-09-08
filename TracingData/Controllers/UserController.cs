using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TracingData.DTO;
using TracingData.Models;

namespace TracingData.Controllers
{
    [ApiController]
    [Route("user/{id}")]
    public class UserController : ControllerBase
    {
        

        private readonly ILogger<UserController> _logger;
        private readonly UserDataContext _userDataContext;

        public UserController(ILogger<UserController> logger, UserDataContext userDataContext)
        {
            _logger = logger;
            _userDataContext = userDataContext;

        }

        [HttpGet]
        public User Get(int id)
        {
            var data = _userDataContext.Users.FirstOrDefault(u=>u.UserId==1);
            return new User() { name=data.UserName,age=data.Age, email=data.UserEmail };
        }
    }
}

using System;
using System.Collections.Generic;

namespace UserDataAPI.Models
{
    public partial class Users
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
    }
}

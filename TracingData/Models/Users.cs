using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TracingData.Models
{
    public partial class Users
    {
        [IgnoreDataMember]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int? Age { get; set; }
    }
}

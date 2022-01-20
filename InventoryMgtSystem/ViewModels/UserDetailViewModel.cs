using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class UserDetailViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
    }
}

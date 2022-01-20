using System;

namespace Models
{
    public class TokenViewModel
    {
        public string accessToken { get; set; }
        public DateTime accessTokenExpiryTime { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
    }
}

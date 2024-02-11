using System;

namespace BookManagement.Models
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Sample.Domain.Users
{
    public class User
    {
        public Guid ID { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        //public User(string username, string email)
        //{
        //    ID = Guid.NewGuid();
        //    Username = username;
        //    Email = email;
        //}
    }
}

using System.Text.RegularExpressions;

namespace LabMVCConferen.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        //public User(int id,string name,string phone, string email, string password)
        //{
        //    Id = id;
        //    Name = name;
        //    Phone = phone;
        //    Email = email;
        //    Password = password;
        //}

        public User()
        {

        }
        public string InfoUser() => $"Lodin - {Email}, Password - {Password}";

    }
}

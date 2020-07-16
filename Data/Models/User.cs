using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public int? StoreId { get; set; }
        public bool Status { get; set; }

        public Role Role { get; set; }
        public Store Store { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

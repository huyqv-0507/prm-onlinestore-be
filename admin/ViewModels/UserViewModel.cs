using System;
using System.Collections.Generic;
using Data.Models;

namespace admin.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(List<User> users, string fullName, string username, int roleId, string storesAddress, bool status)
        {
            Users = users;
            FullName = fullName;
            Username = username;
            RoleId = roleId;
            StoresAddress = storesAddress;
            Status = status;
        }

        public List<User> Users { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string StoresAddress { get; set; }
        public bool Status { get; set; }
    }
}

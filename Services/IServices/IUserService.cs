using System;
using Data.Models;

namespace Services.IServices
{
    public interface IUserService
    {
        public User GetUser(dynamic username);
        void Save();
    }
}

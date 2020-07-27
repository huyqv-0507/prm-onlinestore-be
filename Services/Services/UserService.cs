using System;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Services.IServices;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public User GetUser(dynamic username)
        {
            return _repository.GetByDynamicId(username);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}

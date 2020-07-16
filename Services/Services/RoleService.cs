using System;
using System.Linq;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Services.IServices;

namespace Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddRole(Role role)
        {
            _repository.Add(role);
        }

        public IQueryable<Role> getRoles()
        {
            return _repository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}

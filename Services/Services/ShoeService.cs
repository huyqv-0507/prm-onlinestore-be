using System;
using System.Linq;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Services.IServices;

namespace Services.Services
{
    public class ShoeService : IShoeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoeRepository _repository;
        public ShoeService(IUnitOfWork unitOfWork, IShoeRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void AddShoe(Shoe shoe)
        {
            _repository.Add(shoe);
        }

        public void DeleteShoe(Shoe shoe)
        {
            _repository.Delete(shoe);
        }

        public Shoe GetShoe(int shoeId)
        {
            return _repository.GetById(shoeId);
        }

        public IQueryable<Shoe> GetShoes()
        {
            return _repository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateShoe(Shoe shoe)
        {
            _repository.Update(shoe);
        }
    }
}

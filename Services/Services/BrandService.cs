using System;
using System.Linq;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Services.IServices;

namespace Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandRepository _repository;

        public BrandService(IUnitOfWork unitOfWork, IBrandRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public void AddBrand(Brand brand)
        {
            _repository.Add(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            _repository.Delete(brand);
        }

        public Brand GetBrand(int brandId)
        {
            return _repository.GetById(brandId);
        }

        public IQueryable<Brand> getBrands()
        {
           return _repository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateBrand(Brand brand)
        {
            _repository.Update(brand);
        }
    }
}

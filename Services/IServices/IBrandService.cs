using System;
using System.Linq;
using Data.Models;

namespace Services.IServices
{
    public interface IBrandService
    {
        IQueryable<Brand> getBrands();
        void AddBrand(Brand brand);
        void DeleteBrand(Brand brand);
        void UpdateBrand(Brand brand);
        Brand GetBrand(int brandId);
        void Save();
    }
}

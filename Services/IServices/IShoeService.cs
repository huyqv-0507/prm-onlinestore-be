using System;
using System.Linq;
using Data.Models;

namespace Services.IServices
{
    public interface IShoeService
    {
        IQueryable<Shoe> GetShoes();
        Shoe GetShoe(int shoeId);
        void AddShoe(Shoe shoe);
        void DeleteShoe(Shoe shoe);
        void UpdateShoe(Shoe shoe);
        void Save();
    }
}

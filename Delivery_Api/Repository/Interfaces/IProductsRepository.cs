using Delivery_Api.Models;

namespace Delivery_Api.Repository.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> Get();
        Task<Products> GetById(Guid id);
        void Create(Products products);
        void Update(Products products);
        void Delete(Products products);
        Task<bool> SaveChangesAsync();
    }
}

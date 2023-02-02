using Delivery_Api.Models;

namespace Delivery_Api.Services.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Products>> Get();
        Task<Products> GetById(Guid id);
        Task<bool> Create(Products products);
        Task<bool> Update(Guid id, Products products);
        Task<bool> Delete(Guid id);
    }
}

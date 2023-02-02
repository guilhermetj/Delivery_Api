using Delivery_Api.Extensions;
using Delivery_Api.Models;
using Delivery_Api.Repository;
using Delivery_Api.Repository.Interfaces;
using Delivery_Api.Services.Interfaces;

namespace Delivery_Api.Services
{
    public class ProductsService : IProductsService
    {
        IProductsRepository _repository;
        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Products products)
        {
            _repository.Create(products);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Update(Guid id, Products products)
        {
            var productsBanco = await _repository.GetById(id);
            if (productsBanco == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }
            productsBanco.Name = products.Name;
            productsBanco.Description = products.Description;
            productsBanco.Price = products.Price;
            productsBanco.Image = products.Image;

            _repository.Update(productsBanco);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Delete(Guid id)
        {
            var productsBanco = await _repository.GetById(id);
            if (productsBanco == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            _repository.Delete(productsBanco);

            return await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Products>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Products> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }


    }
}

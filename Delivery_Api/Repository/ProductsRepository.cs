using Delivery_Api.Data;
using Delivery_Api.Models;
using Delivery_Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Delivery_Api.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DeliveryDBContext _context;
        public ProductsRepository(DeliveryDBContext context)
        {
            _context = context;
        }
        public void Create(Products products)
        {
            _context.Add(products);
        }
        public void Update(Products products)
        {
            _context.Update(products);
        }
        public void Delete(Products products)
        {
            _context.Remove(products);
        }

        public async Task<IEnumerable<Products>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetById(Guid id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}

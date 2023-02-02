using Delivery_Api.Models;
using Delivery_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Delivery_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _service.Get();

            return products.Any()
                                ? Ok(products)
                                : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var products = await _service.GetById(id);

            return products != null ? Ok(products) : NotFound("Produto não encontrado");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Products request)
        {
            return await _service.Create(request) ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Products request)
        {
            return await _service.Update(id, request) ? Ok("Editado com sucesso") : BadRequest("Error ao Editar");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await _service.Delete(id) ? Ok("Deletado com sucesso") : BadRequest("Error ao Deletar");
        }
    }
}

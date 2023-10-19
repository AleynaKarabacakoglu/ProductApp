using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Commands;
using ProductApp.Application.Features.Queries;
using ProductApp.Application.Interfaces.Repository;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductRepository _productRepository;
        //public ProductController(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var productList = await _productRepository.GetAllAsync();
        //    return Ok(productList);
        //}
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var productList = await _mediator.Send(query);
            return Ok(productList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

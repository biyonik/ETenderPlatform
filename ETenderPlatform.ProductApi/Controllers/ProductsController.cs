using System.Net;
using ETenderPlatform.ProductApi.Entities;
using ETenderPlatform.ProductApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETenderPlatform.ProductApi.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _productRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:length(36)}", Name = "GetById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await _productRepository.GetById(id);
        if (product != null) return Ok(product);
        _logger.LogError("Product with id: {0}, hasn\'t been found in database", id);
        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<Product>> Create([FromBody] Product product)
    {
        await _productRepository.Create(product);
        return CreatedAtRoute("GetById", new { id = product.Id }, product);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        var result = await _productRepository.Update(product);
        if (!result) return BadRequest();
        return Ok();
    }

    [HttpDelete("{id:length(36)}")]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _productRepository.Delete(id);
        if (!result) return BadRequest();
        return Ok();
    }
}
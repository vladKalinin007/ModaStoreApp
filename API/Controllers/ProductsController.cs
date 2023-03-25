using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _repo.GetProductsAsync();

        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProducts(int id)
    {
        var product = await _repo.GetProductsByIdAsync(id);
        return Ok(product);
    }
    
    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        var productBrands = await _repo.GetProductBrandsAsync();

        return Ok(productBrands);
    } 
    
    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        var productTypes = await _repo.GetProductTypesAsync();

        return Ok(productTypes);
    }
}
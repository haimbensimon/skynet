using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrasturture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _reop;
        
        public ProductsController(IProductRepository reop)
        {
            _reop = reop;
           
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _reop.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
           
            return await  _reop.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetBrands()
        {
            var productsBrands = await _reop.GetBrandsAsync();
            return Ok(productsBrands);
        }

        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetBrand(int id)
        {
           
            return await  _reop.GetProductBrandByIdAsync(id);
        }
        [HttpGet("types")]
         public async Task<ActionResult<List<ProductType>>> GetTypes()
        {
            var productsTypes = await _reop.GettypesAsync();
            return Ok(productsTypes);
        }

        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetType(int id)
        {
           
            return await  _reop.GetProductTypeByIdAsync(id);
        }
    }
}
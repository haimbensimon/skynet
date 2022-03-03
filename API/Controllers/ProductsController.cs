using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrasturture.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class ProductsController:BaseApiController
    {
        
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _typesRepo ;
        private readonly IGenericRepository<ProductBrand> _brandRepo ;
        private readonly IMapper _mapper ;
        
        public ProductsController(IGenericRepository<Product> productRepo ,
        IGenericRepository<ProductBrand> brandRepo, IGenericRepository<ProductType> typesRepo,IMapper mapper)
        {
            _mapper = mapper;
            _brandRepo  = brandRepo;
            _typesRepo = typesRepo;
            _productRepo = productRepo;
           
           
        }
        [HttpGet]
        public async Task<ActionResult<Paginations<ProductToReturn>>> GetProducts([FromQuery]ProducySpecParams productParams)
        {
            var spec = new ProductsWithtypeAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFilterForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product> , IReadOnlyList<ProductToReturn>>(products);

            return Ok(new Paginations<ProductToReturn>(productParams.PageIndex,productParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse) ,StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturn>> GetProduct(int id)
        {
            var spec = new ProductsWithtypeAndBrandsSpecification(id);
            var product = await  _productRepo.GetEntityWithSpec(spec);
            if(product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product , ProductToReturn>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetBrands()
        {
            var productsBrands = await _brandRepo.GetAllAsync();
            return Ok(productsBrands);
        }

        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetBrand(int id)
        {
           
            return await  _brandRepo.GetByIdAsync(id);
        }
        [HttpGet("types")]
         public async Task<ActionResult<List<ProductType>>> GetTypes()
        {
            var productsTypes = await _typesRepo.GetAllAsync();
            return Ok(productsTypes);
        }

        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetType(int id)
        {
           
            return await  _typesRepo.GetByIdAsync(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithFilterForCountSpecification : BaseSpecification<Product>
    {
       public ProductsWithFilterForCountSpecification(ProducySpecParams productsParams)
        :base(x =>
           (string.IsNullOrEmpty(productsParams.Search) || x.Name.ToLower().Contains(productsParams.Search)) &&
           (!productsParams.BrandId.HasValue || x.ProductBrandId == productsParams.BrandId) &&  
        
            (!productsParams.TypeId.HasValue || x.ProductTypeId == productsParams.TypeId) 
        ) 
        {
            
        }
    }
}
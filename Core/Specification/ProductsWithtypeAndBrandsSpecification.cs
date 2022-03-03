using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithtypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithtypeAndBrandsSpecification(ProducySpecParams productsParams)
        :base(x =>
           (string.IsNullOrEmpty(productsParams.Search) || x.Name.ToLower().Contains(productsParams.Search)) &&
           (!productsParams.BrandId.HasValue || x.ProductBrandId == productsParams.BrandId) &&  
        
            (!productsParams.TypeId.HasValue || x.ProductTypeId == productsParams.TypeId) 
        )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType); 
            AddOrderBy(x => x.Name);
            ApplyPaging(productsParams.PageSize * (productsParams.PageIndex -1),productsParams.PageSize);

            if(!string.IsNullOrEmpty(productsParams.Sort))
            {
                switch (productsParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                    AddOrderBy(x => x.Name);
                        break;
                }
                
            }
        }

        public ProductsWithtypeAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
             AddInclude(x => x.ProductBrand);
             AddInclude(x => x.ProductType); 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrasturture.Data
{
    public class SpecificationValuater<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> spec)
        {
           var query = inputQuery;
           if(spec.Critiria != null) 
           {
               query = query.Where(spec.Critiria);
           }

           if(spec.OredrBy != null) 
           {
               query = query.OrderBy(spec.OredrBy);
           }

           if(spec.OredrByDescending != null) 
           {
               query = query.OrderByDescending(spec.OredrByDescending);
           }

           if (spec.IsPagingEnabled)
           {
               query = query.Skip(spec.Skip).Take(spec.Take);
           }

           query = spec.Includes.Aggregate(query , (current , include) => current.Include(include));
           return query;
        }
    }
}
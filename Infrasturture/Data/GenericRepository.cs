using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrasturture.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context ;
        public GenericRepository(StoreContext context)
        {
            _context = context;
            
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecificatioin(spec).CountAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecificatioin(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecificatioin(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecificatioin(ISpecification<T> spec)
        {
            return SpecificationValuater<T>.GetQuery(_context.Set<T>().AsQueryable() , spec);
        }
    }
}
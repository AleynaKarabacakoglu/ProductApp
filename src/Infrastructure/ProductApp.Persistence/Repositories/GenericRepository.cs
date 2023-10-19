using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Domain.Common;
using ProductApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext applicationDbContext;
        public GenericRepository(ApplicationDbContext context) 
        {
            this.applicationDbContext = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await applicationDbContext.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await applicationDbContext.Set<T>().FindAsync(id);
            return entity;
        }
    }
}

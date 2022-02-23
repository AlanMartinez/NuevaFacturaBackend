using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public AppDbContext Context { get; set; }
        public DbSet<T> Entities { get; set; }

        public BaseRepository(AppDbContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

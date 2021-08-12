using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeenServer.Domain;
using SeenServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SeenServer.Repositories
{
    public class RepoBase<TE> : IRepoBase<TE> where TE : EntityBase
    {
        private readonly DbSet<TE> _dbSet;

        protected RepoBase(DbContext databaseContext)
        {
            _dbSet = databaseContext.Set<TE>();
        }

        public async Task DeleteAsync(TE e)
        {
            var entity = await _dbSet.FindAsync(e.Id);
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<TE> tes)
        {
            _dbSet.RemoveRange(tes);
        }

        public IQueryable<TE> GetAll()
        {
            return _dbSet;
        }

        public async Task<TE> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TE> GetById(long id)
        {
            return _dbSet.Where(e => e.Id == id);
        }

        public async Task<TE> InsertAsync(TE e)
        {
            e.Created = DateTime.Now;
            var entry = await _dbSet.AddAsync(e);
            return entry.Entity;
        }

        public async Task InsertAsync(IEnumerable<TE> e)
        {
            foreach (var te in e)
            {
                te.Created = DateTime.Now;
            }
            await _dbSet.AddRangeAsync(e);
        }

        public TE Update(TE e)
        {
            e.LastModified = DateTime.Now;
            _dbSet.Update(e);
            return e;
        }

        public async Task DeleteByIdAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public IEnumerable<TE> UpdateAsync(IEnumerable<TE> tes)
        {
            foreach (var te in tes)
            {
                te.LastModified = DateTime.Now;
            }

            _dbSet.UpdateRange(tes);
            return tes;
        }
    }
}

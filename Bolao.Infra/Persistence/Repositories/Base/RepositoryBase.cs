using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bolao.Domain.Interfaces.Repositories.Base;
using Bolao.Infra.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace Bolao.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected BolaoContext _context { get; set; }

        public RepositoryBase(BolaoContext context)
        {
            this._context = context;
        }

		public TEntity Find(int id)
		{
			return this._context.Set<TEntity>().Find(id);
		}

		public TEntity Find(Guid id)
		{
			return this._context.Set<TEntity>().Find(id);
		}

		public async Task<TEntity> FindAsync(int id)
		{
			return await this._context.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> FindAsync(Guid id)
		{
			return await this._context.Set<TEntity>().FindAsync(id);
		}

		public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByConditionAync(Expression<Func<TEntity, bool>> expression)
        {
            return await this._context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public void Create(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            this._context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
        }
    }
}
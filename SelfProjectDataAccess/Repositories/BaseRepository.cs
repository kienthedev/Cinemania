using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;
using System.Linq.Expressions;

namespace SelfProjectDataAccess.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly SelfProjectContext _context;

        public BaseRepository(SelfProjectContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public virtual T Find(params object[] key)
        {
            return _dbSet.Find(key);
        }

        public virtual void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public virtual int Add(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                throw exp;
            }
        }

        public virtual int Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public virtual int Delete(params object[] key)
        {
            var entity = _dbSet.Find(key);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return _context.SaveChanges();
            }
            return default;
        }

        public virtual IEnumerable<T> GetAllInclude(params string[] includeProps)
        {
            var query = _dbSet.AsQueryable();
            if (includeProps.Length > 0)
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }

        public virtual IEnumerable<T> GetInclude(Expression<Func<T, bool>> filter, params string[] includeProps)
        {
            var query = _dbSet.AsQueryable();
            if (includeProps.Length > 0)
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }
            return query.Where(filter).ToList();
        }



        public virtual T FirstOrDefaultInclude(Expression<Func<T, bool>> filter, params string[] includeProps)
        {
            var query = _dbSet.AsQueryable();
            if (includeProps.Length > 0)
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault(filter);
        }
    }
}

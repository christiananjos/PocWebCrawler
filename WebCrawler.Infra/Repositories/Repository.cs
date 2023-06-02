using WebCrawler.Domain.Interfaces;
using WebCrawler.Domain.Models;
using WebCrawler.Infra.Context;

namespace WebCrawler.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public virtual TEntity GetById(Guid id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == id);

            if (!query.Any()) return null;

            return query.FirstOrDefault();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();

            if (query.Any()) return query.ToList();

            return new List<TEntity>();
        }
        public virtual void Save(TEntity entity) => _context.Set<TEntity>().Add(entity);
    }
}

using WebCrawler.Domain.Models;
using WebCrawler.Infra.Context;

namespace WebCrawler.Infra.Repositories
{
    public class CourseRepository : Repository<Course>
    {
        public CourseRepository(AppDbContext context) : base(context)
        { }

        public override Course GetById(Guid id)
        {
            var query = _context.Set<Course>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Course> GetAll()
        {
            var query = _context.Set<Course>();

            return query.Any() ? query.ToList() : new List<Course>();
        }
    }
}

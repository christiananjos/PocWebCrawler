using WebCrawler.Domain.Interfaces;
using WebCrawler.Domain.Models;

namespace WebCrawler.Domain.Services
{
    public class CourseService
    {
        private readonly IRepository<Course> _courseRepository;
        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public void Save(Guid id, string title, string description, string teacherName, string hours)
        {
            var course = _courseRepository.GetById(id);

            if (course == null)
            {
                course = new Course(title, description, teacherName, hours);
                _courseRepository.Save(course);
            }
            else
                course.Update(title, description, teacherName, hours);
        }
    }
}

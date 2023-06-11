using System.ComponentModel.DataAnnotations;

namespace WebCrawler.API.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; private set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        public string Hours { get; private set; }

        [Required]
        public string TeacherName { get; private set; }
    }
}

using System;

namespace Console.Models
{
    public class CourseDetails
    {
        public Guid CourseDetailsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public string TeacherName { get; set; }
        public CourseDetails() { }

    }
}

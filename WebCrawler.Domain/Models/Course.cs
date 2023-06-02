namespace WebCrawler.Domain.Models
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Hours { get; set; }
        public string TeacherName { get; set; }

        public Course(string title, string description, string teacherName, string hours)
        {
            CourseValidate(title, description, teacherName, hours);

            Title = title;
            Description = description;
            TeacherName = teacherName;
            Hours = hours;
        }

        public void Update(string title, string description, string teacherName, string hours)
        {
            CourseValidate(title, description, teacherName, hours);
        }

        private void CourseValidate(string title, string description, string teacherName, string hours)
        {
            if (string.IsNullOrEmpty(title))
                throw new InvalidOperationException("O titulo é inválido");

            if (string.IsNullOrEmpty(description))
                throw new InvalidOperationException("A descrição é inválida");

            if (string.IsNullOrEmpty(teacherName))
                throw new InvalidOperationException("O nome do professor é inválida");

            if (string.IsNullOrEmpty(hours))
                throw new InvalidOperationException("O campo Carga horaria deve ser preenchido");
        }
    }
}

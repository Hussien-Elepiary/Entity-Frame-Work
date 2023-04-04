namespace RelationShips.Entities.ManyToMany
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //Nav prop => Many
        //public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public ICollection<StudentCourse> CourseStudents { get; set; } = new HashSet<StudentCourse>();
    }
}

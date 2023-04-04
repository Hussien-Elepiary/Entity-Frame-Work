namespace RelationShips.Entities.ManyToMany
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set;}

        //Nav prop => Many
        //public ICollection<Course> Courses { get; set; }= new HashSet<Course>();

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}

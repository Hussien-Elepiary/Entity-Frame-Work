using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationShips.Entities.ManyToMany
{
    internal class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public int Grade { get; set; }

        //Nav One
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}

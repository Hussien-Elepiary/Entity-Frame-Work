using Join_And_GroupJoin.Contexts;

namespace Join_And_GroupJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MiniCompanyDbContext context = new MiniCompanyDbContext();

            #region LinQ Join Oprators

            #region Join()
            //var result = from e in context.Employees
            //             join D in context.Departments
            //                 on /*FK*/ e.DepartmentId equals /*PK*/D.Id
            //             where D.Id == 1
            //             select new
            //             {
            //                 EmpName = e.name,
            //                 DeptName = D.Name
            //             };

            //result = context.Employees.Join(context.Departments,
            //                                E => E.DepartmentId,
            //                                D => D.Id,
            //                                (E, D) => new { EmpName = E.name, DeptName = D.Name })
            //                           .Where(D => D.DeptName == "C#");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region GroupJoin()

            #region Have An Error Trying to Fix it
            //var EmployeesByDepartment = context.Employees.GroupJoin(context.Departments,
            //                                                          E => E.DepartmentId,
            //                                                          D => D.Id,
            //                                                          (E, D) => new { Emps = E, Depts = D });

            var EmployeesByDepartment = from emp in context.Employees
                                        join e in context.Employees
                                        on emp.DepartmentId equals e.DepartmentId
                                        into EmpGroup
                                        select new
                                        {
                                            Employees = EmpGroup.ToList(),
                                            Dept = emp.Department.Name,
                                        };

            foreach (var Dept in EmployeesByDepartment.ToList())
            {
                Console.WriteLine(Dept.Dept);
                foreach (var Emps in Dept.Employees)
                {
                    Console.WriteLine($" {Emps.name}");
                }
            }
            #endregion

            #region https://www.tutorialsteacher.com/linq/linq-joining-operator-groupjoin
            //IList<Student> studentList = new List<Student>() {
            //    new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
            //    new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
            //    new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
            //    new Student() { StudentID = 4, StudentName = "Ram",  StandardID =2 },
            //    new Student() { StudentID = 5, StudentName = "Ron" }
            //};

            //IList<Standard> standardList = new List<Standard>() {
            //    new Standard(){ StandardID = 1, StandardName="Standard 1"},
            //    new Standard(){ StandardID = 2, StandardName="Standard 2"},
            //    new Standard(){ StandardID = 3, StandardName="Standard 3"}
            //};

            //var groupJoin = standardList.GroupJoin(studentList,  //inner sequence
            //                                std => std.StandardID, //outerKeySelector 
            //                                s => s.StandardID,     //innerKeySelector
            //                                (std, studentsGroup) => new // resultSelector 
            //                                {
            //                                    Students = studentsGroup,
            //                                    StandarFulldName = std.StandardName
            //                                });

            //foreach (var item in groupJoin)
            //{
            //    Console.WriteLine(item.StandarFulldName);

            //    foreach (var stud in item.Students)
            //        Console.WriteLine(stud.StudentName);
            //} 
            #endregion
            #endregion

            #endregion
        }

        #region Just Fro the Example https://www.tutorialsteacher.com/linq/linq-joining-operator-groupjoin
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int StandardID { get; set; }
        }

        public class Standard
        {
            public int StandardID { get; set; }
            public string StandardName { get; set; }
        }
        #endregion
    }
}
using DataBase_First.Data;

namespace DataBase_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// 2 ways to make DBFirst Aproush 
            /// 
            /// 1st way
            /// 
            /// in the PM Console
            /// Right the Following
            /// Scaffold-DbContext "server=.; DataBase= Northwind; trusted_connection = true" microsoft.EntityFrameWorkCore.SQLServer
            /// this will make a model for evey table and view in the database 
            /// making some modification like the following to make it more clean 
            /// Scaffold-DbContext "server=.; DataBase= Northwind; trusted_connection = true" microsoft.EntityFrameWorkCore.SQLServer -Tables Categories,Products,Suppliers,"Products Above Average Price" -context NorthContext -contextDir Data -OutPutDir Models -DataAnnotation
            ///
            /// 2nd Way Download the Following Extintion Design Tool EF Core Power Tool By ErikEJ
            /// 

            using NorthwindContext context = new NorthwindContext();


        }
    }
}
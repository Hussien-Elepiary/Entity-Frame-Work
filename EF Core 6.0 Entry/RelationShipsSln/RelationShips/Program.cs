using RelationShips.Contexts;
using RelationShips.Entities.OneToMany;

namespace RelationShips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using OneToManyRelationsContext dbcontext = new OneToManyRelationsContext();
        }
    }
}
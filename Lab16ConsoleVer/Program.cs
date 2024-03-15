using Lab16Lib.BinaryTree;
using Lab16Lib.DumpLoaders;
using Lab16Lib.Entities;
using Lab16Lib.Randomizers;
using Lab16Lib.Utils;

namespace Lab16ConsoleVer
{
    public static class Program
    {
        public static void Main()
        {
            var jdl = new JsonDumpLoader<List<Person>>();
            var xmldl = new XmlDumpLoader<List<Person>>();
            // var bdl = new BinaryDumpLoader<List<Person>>();

            {
                List<Person> people = [];
                people.AddRange(RandomPersonGenerator.GetRandomPersons(10));
                people.Sort(new PersonComparerOut());

                if (!jdl.Dump(people, "Resources/people.json")) throw new Exception("something went wrong");
                if (!xmldl.Dump(people, "Resources/people.xml")) throw new Exception("something went wrong");
                // if (!bdl.Dump(people, "Resources", "people.dat")) throw new Exception("something went wrong");
            }

            {
                var people = jdl.Load("Resources/people.json");
                Console.WriteLine(people);
            }

            {
                var people = xmldl.Load("Resources/people.xml");
                Console.WriteLine(people);
            }

            // {
            //     var people = bdl.Load("Resources/people.dat");
            //     Console.WriteLine(people);
            // }
        }
    }
}
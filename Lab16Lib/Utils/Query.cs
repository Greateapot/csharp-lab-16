using Lab16Lib.Entities;

namespace Lab16Lib.Utils
{
    public static class Query
    {
        public static IEnumerable<Person> GetPersonsWithAgeGreaterThan(
            this List<Person> people,
            int age
        ) => people.Where(e => e.Age > age);

        public static void SortByAge(
            this List<Person> people
        ) => people.Sort((a, b) => a.Age.CompareTo(b.Age));

        public static void SortByLastName(
            this List<Person> people
        ) => people.Sort((a, b) => a.LastName.CompareTo(b.LastName));

        public static void SortByKey(
            this List<Person> people
        ) => people.Sort(new PersonComparerIn());
    }
}
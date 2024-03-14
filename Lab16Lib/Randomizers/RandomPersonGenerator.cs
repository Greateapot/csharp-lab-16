using Lab16Lib.Entities;

namespace Lab16Lib.Randomizers
{
    public static class RandomPersonGenerator
    {
        private static readonly Random random = new((int)DateTimeOffset.Now.ToUnixTimeMilliseconds());

        public static Person[] GetRandomPersons(int count)
        {
            Person[] persons = new Person[count];
            for (int index = 0; index < count; index++)
                persons[index] = (random.Next() % 4) switch
                {
                    0 => GetRandomPerson(),
                    1 => GetRandomPupil(),
                    2 => GetRandomStudent(),
                    _ => GetRandomPartTimeStudent(),
                };
            return persons;
        }

        public static Person GetRandomPerson() => new()
        {
            FirstName = RandomFieldGenerator.FirstName(),
            LastName = RandomFieldGenerator.LastName(),
            Age = RandomFieldGenerator.Age(Person.MinAge, Person.MaxAge),
        };

        public static Pupil GetRandomPupil() => new()
        {
            FirstName = RandomFieldGenerator.FirstName(),
            LastName = RandomFieldGenerator.LastName(),
            Age = RandomFieldGenerator.Age(Person.MinAge, Person.MaxAge),
            Rating = RandomFieldGenerator.Rating(Pupil.MinRating, Pupil.MaxRating),
            SchoolID = RandomFieldGenerator.SchoolID(),
        };

        public static Student GetRandomStudent() => new()
        {
            FirstName = RandomFieldGenerator.FirstName(),
            LastName = RandomFieldGenerator.LastName(),
            Age = RandomFieldGenerator.Age(Person.MinAge, Person.MaxAge),
            Rating = RandomFieldGenerator.Rating(Student.MinRating, Student.MaxRating),
            UniversityID = RandomFieldGenerator.UniversityID(),
        };

        public static PartTimeStudent GetRandomPartTimeStudent() => new()
        {
            FirstName = RandomFieldGenerator.FirstName(),
            LastName = RandomFieldGenerator.LastName(),
            Age = RandomFieldGenerator.Age(Person.MinAge, Person.MaxAge),
            Rating = RandomFieldGenerator.Rating(Student.MinRating, Student.MaxRating),
            UniversityID = RandomFieldGenerator.UniversityID(),
            RandomID = RandomFieldGenerator.RandomID(),
        };
    }
}
using Lab16Lib.Exceptions;

namespace Lab16Lib.Entities
{
    [Serializable]
    public class Person : IEquatable<Person>, IComparable<Person>, ICloneable
    {
        public const int MinAge = 1;
        public const int MaxAge = 120;

        private string? firstName;
        private string? lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person() { }

        public string FirstName
        {
            get => firstName ?? "--";
            set => firstName = value.Length == 0 ? throw new InvalidFieldValueException() : value;
        }
        public string LastName
        {
            get => lastName ?? "--";
            set => lastName = value.Length == 0 ? throw new InvalidFieldValueException() : value;
        }
        public int Age
        {
            get => age;
            set => age = value < MinAge || value > MaxAge ? throw new InvalidFieldValueException() : value;
        }

        public virtual Person ToPerson() => new()
        {
            FirstName = FirstName,
            LastName = LastName,
            Age = Age,
        };
        public override string ToString() => $"Person#{GetHashCode()}(lastName: \"{LastName}\", firstName: \"{FirstName}\", age: {Age})";

        public override int GetHashCode() => (FirstName, LastName, Age).GetHashCode();

        public override bool Equals(object? obj) => obj is Person other && Equals(other);

        public bool Equals(Person? other) => other is not null && CompareTo(other) == 0;

        public int CompareTo(Person? other) 
        {
            if (other is null)
                throw new ArgumentException("Некорректное значение параметра");

            int c;

            c = LastName.CompareTo(other.LastName);
            if (c != 0) return c;

            c = FirstName.CompareTo(other.FirstName);
            if (c != 0) return c;

            c = Age.CompareTo(other.Age);
            if (c != 0) return c;

            return 0;
        }

        public object Clone() => new Person(FirstName, LastName, Age);

        public static bool operator ==(Person left, Person right) => left is null ? right is null : left.Equals(right);

        public static bool operator !=(Person left, Person right) => !(left == right);

        public static bool operator <(Person left, Person right) => left is null ? right is not null : left.CompareTo(right) < 0;

        public static bool operator <=(Person left, Person right) => left is null || left.CompareTo(right) <= 0;

        public static bool operator >(Person left, Person right) => left is not null && left.CompareTo(right) > 0;

        public static bool operator >=(Person left, Person right) => left is null ? right is null : left.CompareTo(right) >= 0;
    }
}
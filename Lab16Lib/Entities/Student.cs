using Lab16Lib.Exceptions;

namespace Lab16Lib.Entities
{
    [Serializable]
    public class Student : Person, IEquatable<Student>, IComparable<Student>, ICloneable
    {
        public const float MinRating = 0;
        public const float MaxRating = 5;

        private float rating;
        private uint universityID;

        public Student(string firstName, string lastName, int age, float rating, uint universityID) : base(firstName, lastName, age)
        {
            Rating = rating;
            UniversityID = universityID;
        }

        public Student() { }

        public float Rating
        {
            get => rating;
            set => rating = value < MinRating || value > MaxRating ? throw new InvalidFieldValueException() : (float)Math.Round(value, 2);
        }
        public uint UniversityID
        {
            get => universityID;
            set => universityID = value == 0 ? throw new InvalidFieldValueException() : value;
        }

        public override string ToString() => $"Student#{GetHashCode()}(lastName: \"{LastName}\", firstName: \"{FirstName}\", age: {Age}, rating: {Rating}, universityID: {UniversityID})";

        public override int GetHashCode() => (FirstName, LastName, Age, Rating, UniversityID).GetHashCode();

        public override bool Equals(object? obj) => obj is Student other && Equals(other);

        public bool Equals(Student? other) => other is not null && CompareTo(other) == 0;

        public int CompareTo(Student? other)
        {
            if (other is null) return 1;
            if (ReferenceEquals(other, this)) return 0;

            int c;

            c = FirstName.CompareTo(other.FirstName);
            if (c != 0) return c;

            c = LastName.CompareTo(other.LastName);
            if (c != 0) return c;

            c = Age.CompareTo(other.Age);
            if (c != 0) return c;

            c = Rating.CompareTo(other.Rating);
            if (c != 0) return c;

            c = UniversityID.CompareTo(other.UniversityID);
            if (c != 0) return c;

            return 0;
        }

        public new object Clone() => new Student(FirstName, LastName, Age, Rating, UniversityID);

        public static bool operator ==(Student left, Student right) => left is null ? right is null : left.Equals(right);

        public static bool operator !=(Student left, Student right) => !(left == right);

        public static bool operator <(Student left, Student right) => left.CompareTo(right) < 0;

        public static bool operator >(Student left, Student right) => left.CompareTo(right) > 0;

        public static bool operator <=(Student left, Student right) => left.CompareTo(right) <= 0;

        public static bool operator >=(Student left, Student right) => left.CompareTo(right) >= 0;
    }
}
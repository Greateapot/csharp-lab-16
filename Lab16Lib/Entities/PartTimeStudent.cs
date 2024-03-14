namespace Lab16Lib.Entities
{
    [Serializable]
    public class PartTimeStudent : Student, IEquatable<PartTimeStudent>, IComparable<PartTimeStudent>, ICloneable
    {
        private int randomID;

        public PartTimeStudent(string firstName, string lastName, int age, float rating, uint universityID, int randomID) : base(firstName, lastName, age, rating, universityID)
        {
            RandomID = randomID;
        }

        public PartTimeStudent() { }

        public int RandomID
        {
            get => randomID;
            set => randomID = value;
        }

        public override string ToString() => $"PartTimeStudent#{GetHashCode()}(lastName: \"{LastName}\", firstName: \"{FirstName}\", age: {Age}, rating: {Rating}, universityID: {UniversityID}, randomID: {RandomID})";

        public override int GetHashCode() => (FirstName, LastName, Age, Rating, UniversityID, RandomID).GetHashCode();

        public override bool Equals(object? obj) => obj is PartTimeStudent other && Equals(other);

        public bool Equals(PartTimeStudent? other) => other is not null && CompareTo(other) == 0;

        public int CompareTo(PartTimeStudent? other)
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

            c = RandomID.CompareTo(other.RandomID);
            if (c != 0) return c;

            return 0;
        }

        public new object Clone() => new PartTimeStudent(FirstName, LastName, Age, Rating, UniversityID, RandomID);

        public static bool operator ==(PartTimeStudent left, PartTimeStudent right) => left is null ? right is null : left.Equals(right);

        public static bool operator !=(PartTimeStudent left, PartTimeStudent right) => !(left == right);

        public static bool operator <(PartTimeStudent left, PartTimeStudent right) => left.CompareTo(right) < 0;

        public static bool operator >(PartTimeStudent left, PartTimeStudent right) => left.CompareTo(right) > 0;

        public static bool operator <=(PartTimeStudent left, PartTimeStudent right) => left.CompareTo(right) <= 0;

        public static bool operator >=(PartTimeStudent left, PartTimeStudent right) => left.CompareTo(right) >= 0;
    }
}
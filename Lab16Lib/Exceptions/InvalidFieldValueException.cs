namespace Lab16Lib.Exceptions
{
    [Serializable]
    public class InvalidFieldValueException : ArgumentException
    {
        public InvalidFieldValueException() { }
        public InvalidFieldValueException(string message) : base(message) { }
        public InvalidFieldValueException(string message, Exception inner) : base(message, inner) { }
    }
}
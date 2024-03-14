namespace Lab16Lib.Exceptions
{
    [Serializable]
    public class RotateArgumentException : Exception
    {
        public RotateArgumentException() { }
        public RotateArgumentException(string message) : base(message) { }
        public RotateArgumentException(string message, Exception inner) : base(message, inner) { }
    }
}
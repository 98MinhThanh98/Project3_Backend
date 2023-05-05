namespace Project3.Utils
{
    public class ValidateException : Exception
    {
        public ValidateException() : base() { }

        public ValidateException(string message) : base(message) { }
    }
}

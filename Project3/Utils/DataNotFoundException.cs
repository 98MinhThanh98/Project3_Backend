namespace Project3.Utils
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException() : base() { }
        public DataNotFoundException(string message) : base(message) { }
    }
}

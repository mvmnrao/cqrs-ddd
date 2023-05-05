namespace Sample.Common.Exceptions
{
    public class ExistingUserException : Exception
    {
        public ExistingUserException(string message) : base(message)
        {
        }
    }
}

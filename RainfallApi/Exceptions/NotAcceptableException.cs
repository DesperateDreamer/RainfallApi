namespace RainfallApi.Exceptions
{
    public class NotAcceptableException : Exception
    {
        public string PropertyName { get; set; }

        public NotAcceptableException(string message, string propertyName) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}

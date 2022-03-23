namespace My_Books.Exceptions
{
    public class InvalidNameException : Exception
    {
        public string name { get; set; }
        public InvalidNameException() : base()
        {

        }
        public InvalidNameException(string message) : base(message)
        {

        }
        public InvalidNameException(string message, string name) : this(message)
        {
            this.name = name;
        }
    }
}

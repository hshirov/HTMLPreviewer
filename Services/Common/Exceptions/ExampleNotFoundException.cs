using System;

namespace Services.Common.Exceptions
{
    public class ExampleNotFoundException : Exception
    {
        public ExampleNotFoundException() { }
        public ExampleNotFoundException(string message) : base(message) { }
        public ExampleNotFoundException(int id) : base(string.Format("Example with id \"{0}\" was not found.", id)) { }
        public ExampleNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}

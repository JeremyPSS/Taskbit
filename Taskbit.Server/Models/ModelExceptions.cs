namespace Taskbit.Server.Models
{
    public class ModelExceptions : ApplicationException
    {
        //Overwriting the constructors of the base class to make custom exceptions
        public ModelExceptions(string message, Exception ex): base(message, ex) { }
        public ModelExceptions(string message): base(message) { }
    }
}

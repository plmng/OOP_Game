namespace Empires.Contracts
{
    /// <summary>
    /// The interface represent the ability of the instance of the class that implements it 
    /// to print messages on concrete output.
    /// Any class that implements the interface contains a definition for an Print method.
    /// </summary>
    public interface IOutputWriter
    {
        void Print(string message);
    }
}

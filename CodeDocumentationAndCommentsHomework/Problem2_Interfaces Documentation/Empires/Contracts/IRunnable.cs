namespace Empires.Contracts
{
    /// <summary>
    /// The interface represents the ability to RUN.
    /// Any class or struct that implements the interface must contain a definition for an Run method 
    /// that matches the signature that the specified in interface. 
    /// </summary>
    public interface IRunnable
    {
        void Run();
    }
}

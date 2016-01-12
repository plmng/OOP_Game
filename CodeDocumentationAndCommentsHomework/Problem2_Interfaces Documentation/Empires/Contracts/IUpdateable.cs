namespace Empires.Contracts
{
    /// <summary>
    /// The interface represent the ability of the object to be updated.
    /// Any class or struct that implements the interface contains a definition for an Update method.
    /// </summary>
    public interface IUpdateable
    {
        void Update();
    }
}

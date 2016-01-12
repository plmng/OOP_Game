namespace Empires.Contracts
{
    /// <summary>
    /// The interface represents the ability of the objects to be destroyed.
    /// Any class or struct that implements the IDestroyable interface contains a Health property,
    /// whose value decreases in the process of destruction of the object.
    /// </summary>
    public interface IDestroyable
    {
        int Health { get; set; }
    }
}

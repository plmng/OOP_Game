namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// The interface represent the basic Resources features - type and quantity.
    /// </summary>
    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}

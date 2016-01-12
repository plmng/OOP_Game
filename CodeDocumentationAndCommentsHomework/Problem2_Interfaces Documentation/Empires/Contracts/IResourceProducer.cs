namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// The interface represents the ability of the object to callback when the resource is produced.
    /// Any class that implements the interface contains the OnResourceProduced event.
    /// </summary>
    public interface IResourceProducer
    {  
        event ResourceProducedEventHandler OnResourceProduced;
    }
}

namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// The interface represents the ability of the object to callback when the unit is produced.
    /// Any class that implements the interface contains the OnUnitProduced event.
    /// </summary>
    public interface IUnitProducer
    {
        event UnitProducedEventHandler OnUnitProduced;
    }
}

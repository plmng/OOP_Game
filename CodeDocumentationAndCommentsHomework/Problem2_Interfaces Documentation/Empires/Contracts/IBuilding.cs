namespace Empires.Contracts
{
    /// <summary>
    /// The IBuilding interface represent the basic Building abilities:
    ///  to callback whe resource is produced, to callback when unit is produced to be updated.
    /// Any class or struct that implements the interface will implement all members of IUnitProducer, IResourceProducer
    ///  and IUpdateable interfaces, that are extended by IBuilding
    /// </summary>
    public interface IBuilding : IUnitProducer, IResourceProducer, IUpdateable
    {
    }
}

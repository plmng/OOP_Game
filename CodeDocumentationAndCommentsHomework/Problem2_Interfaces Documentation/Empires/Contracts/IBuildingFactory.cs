namespace Empires.Contracts
{
    /// <summary>
    /// The interface represents the ability to create buildings.
    /// Any class or struct that implements the interface must contain a definition for an CreateBuilding method 
    /// that matches the signature that the specified in interface. 
    /// </summary>
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}

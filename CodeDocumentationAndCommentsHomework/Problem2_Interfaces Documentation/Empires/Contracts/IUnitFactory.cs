namespace Empires.Contracts
{
    /// <summary>
    /// The interface represents the ability to create units.
    /// Any class or struct that implements the interface must contain a definition for an CreateUnit method 
    /// that matches the signature that the specified in interface. 
    /// </summary>
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}

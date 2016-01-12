namespace Empires.Contracts
{
    /// <summary>
    /// The IUnit interface represent the basic Unit abilities - to attack and to be destroyed.
    /// Any class or struct that implements the interface will implement all members of IAttacker, IDestroyable
    /// interfaces, that are extended by IUnit
    /// </summary>
    public interface IUnit : IAttacker, IDestroyable
    {
    }
}

namespace Empires.Contracts
{
    /// <summary>
    /// The interface represents the ability of the objects to atack and damage to a certain value
    /// represented by the AttackDamage property.
    /// Any class or struct that implements the IAttacker interface contains an AttackDamage property.
    /// </summary>
    public interface IAttacker
    {
        int AttackDamage { get; }
    }
}

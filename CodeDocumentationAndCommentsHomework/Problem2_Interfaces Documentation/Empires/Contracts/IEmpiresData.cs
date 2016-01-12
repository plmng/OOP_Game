namespace Empires.Contracts
{
    using System.Collections.Generic;

    using Enums;

    /// <summary>
    /// The interface represents the set of data in creating and managing buildings module. 
    /// The class that implements the interface containt must contain a definitions of all members, 
    /// matching the signatures that the interface specifies: buildings, units, resources collections 
    /// and methods for adding buldings and adding units. 
    /// </summary>
    public interface IEmpiresData
    {
        IEnumerable<IBuilding> Buildings { get; }

        void AddBuilding(IBuilding building);

        IDictionary<string, int> Units { get; }

        void AddUnit(IUnit unit);

        IDictionary<ResourceType, int> Resources { get; } 
    }
}

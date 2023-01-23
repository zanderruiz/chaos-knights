using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public class Location
    {
        public readonly LocationName LocationName;
        public readonly string Name;
        public readonly string Description;

        public Location(LocationName locationName)
        {
            this.LocationName = locationName;
            Name = GetName(locationName);
            Description = GetDescription(locationName);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Location location = (obj as Location)!;

            return LocationName.Equals(location.LocationName);
        }

        public override int GetHashCode()
        {
            return LocationName.GetHashCode();
        }

        private string GetName(LocationName locationName)
        {
            switch (locationName)
            {
                case LocationName.Church:
                    return "Cathedral";
                case LocationName.Cemetery:
                    return "Mechanicon";
                case LocationName.HermitsCabin:
                    return "Truthseer's Garden";
                case LocationName.WeirdWoods:
                    return "Immaterium";
                case LocationName.UnderworldGate:
                    return "Summoner's Rift";
                default:
                    return "Theif's Guild";
            }
        }

        private string GetDescription(LocationName locationName)
        {
            switch (locationName)
            {
                case LocationName.Church:
                    return "You may draw a White Card.";
                case LocationName.Cemetery:
                    return "You may draw a Black Card.";
                case LocationName.HermitsCabin:
                    return "You may draw a Psychic Card.";
                case LocationName.WeirdWoods:
                    return "You may either give 2 damage to any player or heal 1 damage of any player.";
                case LocationName.UnderworldGate:
                    return "You may draw a card from the stack of your choice.";
                default:
                    return "You may steal an Equipment card from any player.";
            }
        }
    }

    public enum LocationName
    {
        Church,
        Cemetery,
        HermitsCabin,
        WeirdWoods,
        UnderworldGate,
        ErstwhileAltar
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public class LocationMap
    {
        public readonly ReadOnlyCollection<Location> LocationPositions;

        private readonly Dictionary<int, Location> LocationRolls = new Dictionary<int, Location>();

        private readonly Dictionary<Player, Location> PlayerLocation = new Dictionary<Player, Location>();

        private readonly Dictionary<Location, HashSet<Player>> PlayersAtLocation = new Dictionary<Location, HashSet<Player>>();

        public LocationMap()
        {
            // Create 6 main locations
            Location hermitsCabin = new Location(LocationName.HermitsCabin);
            Location underworldGate = new Location(LocationName.UnderworldGate);
            Location church = new Location(LocationName.Church);
            Location cemetery = new Location(LocationName.Cemetery);
            Location weirdWoods = new Location(LocationName.WeirdWoods);
            Location erstwhileAltar = new Location(LocationName.ErstwhileAltar);

            LocationRolls.Add(2, hermitsCabin);
            LocationRolls.Add(3, hermitsCabin);
            LocationRolls.Add(4, underworldGate);
            LocationRolls.Add(5, underworldGate);
            LocationRolls.Add(6, church);
            LocationRolls.Add(8, cemetery);
            LocationRolls.Add(9, weirdWoods);
            LocationRolls.Add(10, erstwhileAltar);

            List<Location> initLocList = new List<Location>();
            initLocList.Add(hermitsCabin);
            initLocList.Add(underworldGate);
            initLocList.Add(church);
            initLocList.Add(cemetery);
            initLocList.Add(weirdWoods);
            initLocList.Add(erstwhileAltar);

            foreach (Location location in initLocList)
            {
                PlayersAtLocation.Add(location, new HashSet<Player>());
            }

            Random locShuffle = new Random();
            initLocList = initLocList.OrderBy(a => locShuffle.Next()).ToList();
            LocationPositions = new ReadOnlyCollection<Location>(initLocList);
        }

        public void MovePlayer(Player player, Location location)
        {
            if (!PlayerLocation.ContainsKey(player)) // If player has not moved to a location yet
            {
                PlayerLocation.Add(player, location);
                PlayersAtLocation[location].Add(player);
            }
            else
            {
                Location prevLocation = PlayerLocation[player];
                PlayerLocation[player] = location;
                PlayersAtLocation[prevLocation].Remove(player);
                PlayersAtLocation[location].Add(player);
            }
        }

        public Tuple<Location, Location> GetAdjacentLocations(Location location)
        {
            int locIndex = LocationPositions.IndexOf(location);

            return Tuple.Create(LocationPositions[(locIndex - 1) % 6], LocationPositions[(locIndex + 1) % 6]);
        }
    }
}

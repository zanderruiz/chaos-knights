using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public class GameTracker
    {
        public readonly Dictionary<int, Player> Players = new Dictionary<int, Player>();

        public readonly LocationMap LocMap = new LocationMap();
    }
}

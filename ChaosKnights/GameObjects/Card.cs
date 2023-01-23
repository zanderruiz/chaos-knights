using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public class Card
    {
        public readonly string Title;
        public readonly string Description;
        public readonly CardColor Color;
        public readonly bool IsEquipment;
    }

    public enum CardColor
    {
        Black,
        White,
        Green
    }
}

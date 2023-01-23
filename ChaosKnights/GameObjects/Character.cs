namespace GameObjects
{
    public class Character
    {
        public string Name { get; private set; }
        public Allegiance allegiance { get; private set; }
        public int MaxHealth { get; private set; }

        // Win condition data
        public delegate bool WinCondition();
        public WinCondition WinCond { get; private set; }
        public string WinCondDesc { get; private set; }

        // Special ability data
        public delegate void SpecialAbility();
        public SpecialAbility Special { get; private set; }
        public string SpecialDesc { get; private set; }

        public Character()
        {
            Name = string.Empty;
            allegiance = Allegiance.Neutral;
            MaxHealth = 0;
            WinCond = () => throw new Exception("No win condition provided.");
            WinCondDesc = string.Empty;
            Special = () => throw new Exception("No special provided.");
            SpecialDesc = string.Empty;
        }

        public Character(string name, Allegiance allegiance, int maxHealth, WinCondition winCond, string winCondDesc, SpecialAbility special, string specialDesc)
        {
            Name = name;
            this.allegiance = allegiance;
            MaxHealth = maxHealth;
            WinCond = winCond;
            WinCondDesc = winCondDesc;
            Special = special;
            SpecialDesc = specialDesc;
        }
    }

    public enum Allegiance
    {
        Knight,
        Neutral,
        Chaos
    }
}
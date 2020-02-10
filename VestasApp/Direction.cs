namespace VestasApp
{
    using System.Linq;

    public class Direction
    {
        public static readonly string[][] PossibleCombinations = { new[] { "NORTH", "SOUTH" }, new[] { "EAST", "WEST" } };
        
        public Direction(string name)
        {
            this.Name = name.ToUpper();
        }

        public string Name { get; set; }

        public bool IsValid()
        {
            foreach (var combination in PossibleCombinations)
            {
                foreach (var c in combination)
                {
                    if (combination.Contains(this.Name))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

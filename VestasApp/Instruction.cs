namespace VestasApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Instruction
    {
        public static readonly string[][] PossibleCombinations = { new[] { "NORTH", "SOUTH" }, new[] { "EAST", "WEST" } };

        public Instruction(string directions)
        {
            var pattern = @"[\[\]\{\}\s\""\\]";
            var replace = Regex.Replace(directions, pattern, string.Empty);

            var directionsArr = replace.Split(',');

            this.TryAdd(directionsArr);
        }

        public Instruction(string[] directions)
        {
            this.TryAdd(directions);
        }

        public List<Direction> Directions { get; set; } = new List<Direction>();

        public bool AddDirection(Direction direction)
        {
            if (direction.IsValid())
            {
                this.Directions.Add(direction);
                return true;
            }

            return false;
        }

        public string[] ToArray()
        {
            return this.Directions.Select(s => s.Name).ToArray();
        }

        private void TryAdd(string[] directions)
        {
            foreach (var item in directions)
            {
                var added = this.AddDirection(new Direction(item));
                if (!added)
                {
                    throw new ArgumentException("Invalid instruction");
                }
            }
        }
    }
}

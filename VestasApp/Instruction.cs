namespace VestasApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Responsible for process the instructions, remove invalid characters and convert to array so Reduce.cs can reduce the instructions
    /// </summary>
    public class Instruction
    {
        public Instruction(string directions)
        {
            var directionsArr = this.ReplaceInvalidCharacters(directions);

            this.TryAdd(directionsArr);
        }
        
        public Instruction(string[] directions)
        {
            this.TryAdd(directions);
        }

        public List<Direction> Directions { get; set; } = new List<Direction>();
        
        public string[] ToArray()
        {
            return this.Directions.Select(s => s.Name.ToString()).ToArray();
        }

        private void TryAdd(string[] directions)
        {
            foreach (var item in directions)
            {
               this.Directions.Add(new Direction(item));
            }
        }

        private string[] ReplaceInvalidCharacters(string directions)
        {
            const string Pattern = @"[\[\]\{\}\s\""\\]";
            var replace = Regex.Replace(directions, Pattern, string.Empty);

            var directionsArr = replace.Split(',');
            return directionsArr;
        }
    }
}

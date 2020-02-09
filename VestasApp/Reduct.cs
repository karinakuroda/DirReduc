namespace VestasApp
{
    using System;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Text.RegularExpressions;

    public class Reduct
    {
        private static readonly string[][] PossibleCombinations = { new[] { "NORTH", "SOUTH" }, new[] { "EAST", "WEST" } };

        private string[] instructions;

        public string[] Instructions
        {
            get => this.instructions;

            set
            {
                this.instructions = value.Select(s => s.ToUpper()).ToArray();
            }
        }

        public Reduct(string[] instructions)
        {
            this.Instructions = instructions;
            this.Validate();
        }

        public Reduct(string textInstructions)
        {
            this.ConvertToArray(textInstructions);
            this.Validate();
        }

        private void ConvertToArray(string textInstructions)
        {
            var pattern = @"[\[\]\{\}\s\""\\]";
            var replace = Regex.Replace(textInstructions, pattern, string.Empty);
            
            this.Instructions = replace.Split(',');
        }

        public bool Validate()
        {
            foreach (var instruction in this.Instructions)
            {
                if (!this.IsValid(instruction))
                {
                    throw new ArgumentException("Invalid instruction");
                }
            }

            return true;
        }

        public string DirReduc()
        {
            for (var i = 0; i < this.Instructions.Length; i++)
            {
                var currentInstruction = this.Instructions[i];
                
                if (this.Instructions.Length <= (i + 1) || this.Instructions.Length <= 1) break;

                var nextInstruction = this.Instructions[i + 1];

                foreach (var combination in PossibleCombinations)
                {
                    if (combination.Contains(currentInstruction) && combination.Contains(nextInstruction) && (currentInstruction != nextInstruction))
                    {
                        this.Instructions = this.Instructions.Where((source, index) => index != i && index != i + 1).ToArray();
                        this.DirReduc();
                    }
                }
            }

            var result = string.Join(", ", this.Instructions.Where(s => !string.IsNullOrEmpty(s)));
            return result;
        }

        private bool IsValid(string instruction)
        {
            foreach (var combination in PossibleCombinations)
            {
                foreach (var c in combination)
                {
                    if (combination.Contains(instruction))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

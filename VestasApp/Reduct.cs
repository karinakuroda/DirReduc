namespace VestasApp
{
    using System;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;

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
            this.Instructions = textInstructions.Split(',');
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

        public string DirReduc()
        {
            for (var i = 0; i < this.Instructions.Length; i++)
            {
                var instruction = this.Instructions[i];

                if (instruction == string.Empty) continue;
                if (instruction.Length < (i + 1)) break;


                var nextInstruction = this.Instructions[i + 1];

                foreach (var combination in PossibleCombinations)
                {
                    if (combination.Contains(instruction) && combination.Contains(nextInstruction))
                    {
                        this.Instructions[i] = string.Empty;
                        this.Instructions[i + 1] = string.Empty;
                    }
                }
            }

            var result = string.Join(",", this.Instructions.Where(s => !string.IsNullOrEmpty(s)));
            return result;
        }
    }
}

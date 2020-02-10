namespace VestasApp
{
    using System.Linq;

    public class Reduct
    {
        private static readonly string[][] PossibleCombinations = { new[] { "NORTH", "SOUTH" }, new[] { "EAST", "WEST" } };
        
        private readonly Instruction instruction;

        private string[] directions;

        public Reduct(string[] instructions)
        {
            this.directions = new Instruction(instructions).ToArray();
        }

        public Reduct(string textInstructions)
        {
            this.directions = new Instruction(textInstructions).ToArray();
        }
        
        public string DirReduc()
        {
            for (var i = 0; i < this.directions.Length; i++)
            {
                var currentInstruction = this.directions[i];
                
                if (this.directions.Length <= (i + 1) || this.directions.Length <= 1) break;

                var nextInstruction = this.directions[i + 1];

                foreach (var combination in PossibleCombinations)
                {
                    if (combination.Contains(currentInstruction) && combination.Contains(nextInstruction) && (currentInstruction != nextInstruction))
                    {
                        this.directions = this.directions.Where((source, index) => index != i && index != i + 1).ToArray();
                        this.DirReduc();
                    }
                }
            }

            var result = string.Join(", ", this.directions.Where(s => !string.IsNullOrEmpty(s)));
            return result;
        }
    }
}

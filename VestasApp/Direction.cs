namespace VestasApp
{
    using System;

    /// <summary>
    /// Responsible for validate the direction informed
    /// </summary>
    public class Direction
    {
        public Direction(string name)
        {
            try
            {
                this.Name = (CardinalDirection)Enum.Parse(typeof(CardinalDirection), name.ToUpper());
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid Direction");
            }
        }

        public CardinalDirection Name { get; set; }
    }
}

namespace VestasApp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;

            while (!exit)
            {
                try
                {
                    ReduceInstructions();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Exit? (Y/N)");
                exit = Console.ReadLine().Equals("Y");
            }
        }

        private static void ReduceInstructions()
        {
            Console.WriteLine("Type instructions:");
            var instructions = Console.ReadLine();

            var result = new Reduce(instructions).DirReduc();

            Console.WriteLine(result);
        }
    }
}

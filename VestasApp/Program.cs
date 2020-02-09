namespace VestasApp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type instructions:");
            var instructions = Console.ReadLine();

            var result = new Reduct(instructions).DirReduc();
            
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

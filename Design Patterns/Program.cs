namespace DesignPatterns
{
    public class StrategyPattern
    {
        public static void PrintSomething()
        {
            Console.WriteLine("From strategy");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DesignPatterns.StrategyPattern.PrintSomething();
    }
}


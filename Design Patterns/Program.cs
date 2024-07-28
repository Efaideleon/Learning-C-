using StrategyPattern;
using CommandPattern;
using System.Runtime.InteropServices;

namespace StrategyPattern
{
    public interface ISortingAlgorithm
    {
        public void Sort();
    }

    public class QuickSort : ISortingAlgorithm
    {
        public void Sort()
        {
            Console.WriteLine("Sorting using QuickSort.");
        }
    }

    public class MergeSort : ISortingAlgorithm
    {
        public void Sort()
        {
            Console.WriteLine("Sorting using MergeSort.");
        }
    }

    public class StrategyPatternProgram
    {
        public static void Run()
        {
            var quickSort = new QuickSort();
            var mergeSort = new MergeSort();

            Sort(quickSort);
            Sort(mergeSort);
        }

        private static void Sort(ISortingAlgorithm sortingAlgorithm)
        {
            sortingAlgorithm.Sort();
        }
    }
}

namespace CommandPattern
{
    public interface ICommand
    {
        public void Execute();
    }

    public class AttackCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Attack!");
        }
    }

    public class JumpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Jump!");
        }
    }

    public class InputHandler
    {
        public ICommand buttonA { get; set;}
        public ICommand buttonB { get; set; }

        public InputHandler(ICommand commandA, ICommand commandB)
        {
            buttonA = commandA;
            buttonB = commandB;
        }
    }

    public class CommandPatternProgram 
    {
        public static void Run()
        {
            InputHandler inputHandler = new InputHandler(new JumpCommand(), new AttackCommand());
            inputHandler.buttonA.Execute(); // button A will jump
            inputHandler.buttonB.Execute(); // button B will attack
        }
    }
}

class Program
{
    static void Main(string [] args)
    {
        // Console.WriteLine("Strategy Pattern: ");
        // StrategyPatternProgram.Main();
        Console.WriteLine("Command Pattern: ");
        CommandPatternProgram.Run();
    }
}


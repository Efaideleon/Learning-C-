using StrategyPattern;
using CommandPattern;

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

    // State pattern practice
    public interface IState{
        public void Enter(Character character);
        public void Execute(Character character);
        public void Exit(Character character);
    }

    public class Idle: IState
    {
        public void Enter(Character character)
        {
            Console.WriteLine("Entering Idle state.");
        }
        
        public void Execute(Character character)
        {
            Console.WriteLine("Executing Idle state.");
        }
        public void Exit(Character character)
        {
            Console.WriteLine("Exiting Idle state.");
        }
    }

    public class Jumping: IState
    {
        public void Enter(Character character)
        {
            Console.WriteLine("Entering Jumping state.");
        }
        
        public void Execute(Character character)
        {
            Console.WriteLine("Executing Jumping state.");
        }
        public void Exit(Character character)
        {
            Console.WriteLine("Exiting Jumping state.");
        }
    }

    public class Character
    {
        private IState? currentState;

        public void ChangeState(IState newState)
        {
            currentState?.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }

        public void Execute()
        {
            currentState?.Execute(this);
        }
    }
}
class Program
{
    static void Main(string [] args)
    {
        // Console.WriteLine("Strategy Pattern: ");
        // StrategyPatternProgram.Main();
        // Console.WriteLine("Command Pattern: ");
        // CommandPatternProgram.Run();
        Console.WriteLine(" State Pattern: ");
        Character player= new();
        player.ChangeState(new Idle());
        player.Execute();
        player.ChangeState(new Jumping());
    }
}


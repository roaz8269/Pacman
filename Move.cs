using System;

public interface IAutoMove
{
    (int row,int col) NextMove();
}

public class HumanMove
{
    public (int row, int col) NextMove()
    {
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.W:
                return (-1, 0);
            case ConsoleKey.S:
                return (1, 0);  
            case ConsoleKey.A:
                return (0, -1);
            case ConsoleKey.D:
                return (0, 1);  
            default:
                return (0,0);
        }
    }
}

/*public class RandomMove : IAutoMove
{
    public (int row, int col) NextMove()
    {
        // randomiserad rörelse
    }
}


public class GoalOrientedMove: IAutoMove
{
    public (int row, int col) NextMove()
    {
        // snabbaste vägen
    }
}*/

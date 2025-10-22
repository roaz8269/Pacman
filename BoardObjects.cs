using System;
public interface IBoardObject
{
    char character { get; } // Ska denna vara char eller T?
    int points { get; }
    bool canMove { get; }
    void Interact(Pacman pacman, Game game);
}

public class Points <T>: IBoardObject
{
    public char character { get; private set; } // detta ska vara T, men funkar ej: vill vara antingen char eller string
    public bool canMove { get; } = true;
    public int points { get; init; }

    public Points(char character, int points)
    {
        this.character = character;
        this.points = points;
    }
    
    public void Interact(Pacman pacman, Game game)
    {
        pacman.AddPoints(points);
    }
}

public class PowerPill: IBoardObject
{
    public char character { get; private set; } // =
    public bool canMove { get; } = true;
    public int points { get;} = 200;

    //Fixa switch funktion
    public void Interact(Pacman pacman, Game game)
    {
        pacman.AddPoints(points);
        game.SwitchMode();
    }
}

public class Wall : IBoardObject
{
    public char character { get; private set; }
    public bool canMove { get; } = false;

    public int points { get; } = 0;

    public void Interact(Pacman pacman, Game game)
    {
        Console.WriteLine("Hit a wall");
    }

}
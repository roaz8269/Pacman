using System;
using System.Reflection.Metadata;

public interface ICharacter
{
    IAutoMove move  {get;}
    ICollision collider { get; }
    char appearence { get; }
    (int x, int y) startPosition { get; }
    (int x, int y) currentPosition { get; }

    void NextMove();
    void Swap(Mode mode);
    void Die();
}

public class Pacman: ICharacter
{
    public IAutoMove move {get; private set;}
    public ICollision collider { get; private set; }
    public char appearence { get; private set; }
    public int score { get; private set; }
    public (int x, int y) startPosition { get; private set; }
    public (int x, int y) currentPosition { get; private set; }
    public int lives { get; private set; } = 3;
    public List<List<IBoardObject>> board;
    PacmanColliderFactory factory = new PacmanColliderFactory();

    public Pacman(ICollision collider, IAutoMove move, char appearence, (int,int) startPosition, List<List<IBoardObject>> board)
    {
        this.move = move;
        this.collider = collider;
        this.appearence = appearence;
        this.startPosition = startPosition;
        currentPosition = startPosition;
        this.board = board;
    }
    public void NextMove()
    {
        (int x, int y) moveDir = move.NextMove();

        (int x, int y) newPosition = (currentPosition.x + moveDir.x,
                                        currentPosition.y + moveDir.x);
        if (board[newPosition.x][newPosition.y].canMove)
        {
            currentPosition = newPosition;
        }
    }

    public void Swap(Mode mode)
    {
        collider = factory.Create(mode, this);
    }
    public void Die()
    {
        currentPosition = startPosition;
        lives--;
    }
    public void AddPoints(int points)
    {
        score += points;
    }

    /*public bool Eat(IBoardObject boardObject)
    {
        bool Switch = false;

        if(boardObject == PowerPill)
        {
            Switch = true;
        }

        score += boardObject.Points;
        return Switch;
    }*/
}

public class Ghost: ICharacter
{
    public IAutoMove move {get; private set;}
    public ICollision collider { get; private set; }
    public char appearence { get; private set; }
    public (int x, int y) startPosition { get; private set; }
    public (int x, int y) currentPosition { get; private set; }
    public List<List<IBoardObject>> board;
    GhostColliderFactory factory = new GhostColliderFactory();

    public Ghost(ICollision collider, IAutoMove move, char appearence, (int,int) startPosition, List<List<IBoardObject>> board)
    {
        this.move = move;
        this.collider = collider;
        this.appearence = appearence;
        this.startPosition = startPosition;
        currentPosition = startPosition;
        this.board = board;
    }
    public void NextMove()
    {
        (int x, int y) moveDir = move.NextMove();

        (int x, int y) newPosition = (currentPosition.x + moveDir.x,
                                        currentPosition.y + moveDir.y);
        if (board[newPosition.x][newPosition.y].canMove)
        {
            currentPosition = newPosition;
        }

    }
    public void Swap(Mode mode)
    {
        collider = factory.Create(mode, this);
    }
    public void Die()
    {
        currentPosition = startPosition;
    }
}

/*public class Ghost: ICharacter
{
    public IMove move {get; private set;}
    public ICollision collision {get; private set; }
    public char appearence { get; private set; }

    public Ghost(ICollision collision, IMove move, char appearence)
    {
        this.move = move;
        this.collision = collision;
        this.appearence = appearence;
    }

    public (int, int) NextMove()
    {
        return move.NextMove();
    }
    
    public void Swap(ICollision collision)
    {
        
    }
}*/

public class GhostColliderFactory
{
    public ICollision Create(Mode mode, ICharacter character)
    {
        return mode switch
        {
            Mode.NotScared => new Hunter(),
            Mode.Scared => new Hunted(character),
            _ => throw new ArgumentOutOfRangeException(nameof(mode))
        };
    }
}

public class PacmanColliderFactory
{
    public ICollision Create(Mode mode, ICharacter character)
    {
        return mode switch
        {
            Mode.Scared => new Hunter(),
            Mode.NotScared => new Hunted(character),
            _ => throw new ArgumentOutOfRangeException(nameof(mode))
        };
    }
}

public enum Mode
{
    Scared,
    NotScared
}
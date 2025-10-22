using System;
public interface ICollision
{
    void CollideWith(ICollision other);
    void CollisionEffect(Hunter other);
    void CollisionEffect(Hunted other);
}
public class Hunter : ICollision
{
    public void CollideWith(ICollision other)
    {
        other.CollisionEffect(this);
    }
    public void CollisionEffect(Hunter other)
    {
        //nothing
    }
    public void CollisionEffect(Hunted other)
    {
        //nothings
    }
}


public class Hunted : ICollision
{
    ICharacter character;
    public Hunted(ICharacter character)
    {
        this.character = character;
    }

    public void CollideWith(ICollision other)
    {
        other.CollisionEffect(this);
    }
    public void CollisionEffect(Hunter other)
    {
        character.Die();
    }

    public void CollisionEffect(Hunted other)
    {
        //nothings
    }
}

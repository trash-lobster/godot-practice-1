using Godot;

public abstract class BaseMovementDirectionComponent : Node
{
    protected Vector2 MovementDirection = Vector2.Zero;

    public Vector2 GetMovementDirection()
    {
        return MovementDirection;
    }

}
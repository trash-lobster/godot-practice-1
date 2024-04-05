using Godot;

public class InputDirectionComponent : BaseMovementDirectionComponent
{
    public override void _Process(float delta)
    {
        MovementDirection = Input.GetVector("move_left", "move_right", "move_up", "move_down");
    }
}
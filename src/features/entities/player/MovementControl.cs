using Godot;

public class MovementControl : Node
{
	[Signal]
	public delegate void SetMovementDirection(Vector2 direction);
	public Vector2 Velocity { get; set; }
	public int Speed { get; set; } = 300;

	public override void _Ready()
	{

	}

	public override void _Process(float delta)
	{
		Velocity = Vector2.Zero;
		var inputDirection = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Velocity = inputDirection * Speed;

		EmitSignal(nameof(SetMovementDirection), Velocity);
	}
}

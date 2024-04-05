using Godot;

public class Bullet : Area2D
{
	[Export]
	public int Speed { get; set; } = 10;
	public string Allegiance { get; set; } = Team.GetNeutral();
	private Vector2 Direction { get; set; } = Vector2.Zero;

	public override void _Ready()
	{
		Connect("body_entered", this, nameof(HandleCollision));
	}

	public override void _PhysicsProcess(float delta)
	{
		if (Direction != Vector2.Zero)
		{
			GlobalPosition += Direction * Speed;
		}
	}

	public void SetDirection(Vector2 value)
	{
		Direction = value;
		Rotation += Direction.Angle();
	}

	public void HandleCollision(HittableEntity body)
	{
		GlobalSignal signals = (GlobalSignal)GetNode("/root/GlobalSignal");
		signals.EmitSignal(nameof(GlobalSignal.Hit), body, Allegiance);
	}
}

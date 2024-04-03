using Godot;

public class Bullet : Area2D
{
	[Export]
	public int Speed { get; set; } = 10;
	public Allegiance Allegiance { get; set; } = Allegiance.NEUTRAL;
	private Vector2 Direction  { get; set; } = Vector2.Zero;

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
		if (body.Allegiance != Allegiance && body.Allegiance != Allegiance.NEUTRAL)
		{
			GD.Print("We are hitting someone we should be hitting!");
			body.HandleHit();
			QueueFree();
		}
	}
}

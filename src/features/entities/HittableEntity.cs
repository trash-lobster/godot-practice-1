using Godot;

public class HittableEntity : KinematicBody2D
{
	public Allegiance Allegiance { get; set; } = Allegiance.NEUTRAL;

	public override void _Ready()
	{
		base._Ready();
	}

	public void HandleHit()
	{
		QueueFree();
	}
}

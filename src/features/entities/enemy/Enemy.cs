using Godot;

public class Enemy : KinematicBody2D
{
	public int Speed { get; set; } = 300;
	public Allegiance Allegiance { get; set; } = Allegiance.ENEMY;

	public override void _Process(float delta)
	{
		base._Process(delta);
	}

	public void HandleHit()
	{
		this.QueueFree();
	}
}

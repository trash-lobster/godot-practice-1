using Godot;

public class Enemy : KinematicBody2D
{
	public int Speed { get; set; } = 300;

	public override void _Ready()
	{
		var hitComponent = new HittableEntity();
		AddChild(hitComponent);
		hitComponent.Allegiance = "enemy";
	}
}

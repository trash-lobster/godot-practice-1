using Godot;

public class Enemy : KinematicBody2D
{
	public int Speed { get; set; } = 100;
	public Vector2 Target = Vector2.Zero;
	public HittableEntity HitComponent;

	public override void _Ready()
	{
		HitComponent = new HittableEntity();
		AddChild(HitComponent);
		HitComponent.Allegiance = "enemy";

		GlobalSignal signals = (GlobalSignal)GetNode("/root/GlobalSignal");
		signals.Connect("SetEnemyTarget", this, "GetTarget");
		signals.Connect("Hit", this, "Die");
	}

	public override void _Process(float delta)
	{
		LookAt(Target);
		MoveAndSlide((Target - Position).Normalized() * Speed);
	}

	public void GetTarget(Vector2 position)
	{
		Target = position;
	}

	public void Die(HittableEntity body, string allegiance)
	{
		body.QueueFree();
	}
}

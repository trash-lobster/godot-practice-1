using Godot;

public class Enemy : HittableEntity
{
	public int Speed { get; set; } = 300;

	public override void _Ready()
	{
		base._Ready();
		Allegiance = Allegiance.ENEMY;
	}
}

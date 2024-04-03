using Godot;

public class Player : HittableEntity
{
	public int Speed { get; set; } = 300;
	public Vector2 MovementDirection { get; set; }
	public MovementControl MovementControl { get; set; }

	public override void _Ready()
	{
		Allegiance = Allegiance.ALLY;
		MovementControl = (MovementControl) GetNode("MovementControl");
		MovementControl.Connect(nameof(MovementControl.SetMovementDirection), this, nameof(GetMovementDirection));
		MovementControl.Speed = Speed;

		// add gun component
		var gun = (Gun) ResourceLoader.Load<PackedScene>("res://src//features//weapon//Gun.tscn").Instance();
		AddChild(gun);
		gun.Allegiance = Allegiance;
	}

	public override void _PhysicsProcess(float delta)
	{
		LookAt(GetGlobalMousePosition());
		MoveAndSlide(MovementDirection * Speed);
	}

	public void GetMovementDirection(Vector2 direction)
	{
		MovementDirection = direction.Normalized();
	}
}

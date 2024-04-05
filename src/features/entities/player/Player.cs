using Godot;

public class Player : KinematicBody2D
{

	public int Speed { get; set; } = 300;
	public Vector2 MovementDirection { get; set; }
	public HittableEntity HittableComponent { get; set; }

	public override void _Ready()
	{
		HittableComponent = new HittableEntity();
		AddChild(HittableComponent);
		HittableComponent.Allegiance = "ally";

		var movementControlComponent = new PlayerMovementControl();
		AddChild(movementControlComponent);
		movementControlComponent.Speed = Speed;
		movementControlComponent.UpdateDirection = (value) => MovementDirection = value;

		// add gun component
		var gun = new Gun();
		AddChild(gun);
		gun.Allegiance = "ally";
	}
	
	public override void _PhysicsProcess(float delta)
	{
		LookAt(GetGlobalMousePosition());
		MoveAndSlide(MovementDirection * Speed);
		GlobalSignal signals = (GlobalSignal)GetNode("/root/GlobalSignal");
		signals.EmitSignal(nameof(GlobalSignal.SetEnemyTarget), Position);
	}

	public void GetMovementDirection(Vector2 direction)
	{
		MovementDirection = direction.Normalized();
	}
}

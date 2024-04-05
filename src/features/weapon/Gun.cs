using Godot;

public class Gun : Node2D
{
	private Timer AttackCooldown { get; set; }
	private Position2D GunTip { get; set; }
	[Export]
	public PackedScene Bullet { get; set; }
	public string Allegiance { get; set; } = "neutral";

	public override void _Ready()
	{	
		AttackCooldown = new Timer
		{
			WaitTime = 0.1f,
			OneShot = true
		};
		AddChild(AttackCooldown);
	
		var position = new Vector2();
		position.x = 16;
		GunTip = new Position2D
		{
			Position = position
		};
		AddChild(GunTip);
	}

	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("shoot") && AttackCooldown.IsStopped())
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		var bullet = ResourceLoader.Load<PackedScene>("res://src//features//weapon//Bullet.tscn").Instance();
		var direction = (GunTip.GlobalPosition - GlobalPosition).Normalized();

		GlobalSignal signals = (GlobalSignal)GetNode("/root/GlobalSignal");
		signals.EmitSignal("BulletFired", (Bullet)bullet, Allegiance, GunTip.GlobalPosition, direction);
		AttackCooldown.Start();
	}

}

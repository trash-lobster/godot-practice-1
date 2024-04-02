using Godot;

public class Gun : Node2D
{
	private Timer AttackCooldown { get; set; }
	private Position2D GunTip { get; set; }
	[Export]
	public PackedScene Bullet { get; set; }
	public Allegiance Allegiance { get; set; }

	public override void _Ready()
	{
		AttackCooldown = GetNode<Timer>("AttackCooldown");
		GunTip = GetNode<Position2D>("GunTip");
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

		GlobalSignal signals = (GlobalSignal) GetNode("/root/GlobalSignal");
		signals.EmitSignal("BulletFired", (Bullet) bullet, Allegiance, GunTip.GlobalPosition, direction);
		AttackCooldown.Start();
	}

}

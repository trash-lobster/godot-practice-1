using Godot;

public class BulletManager : Node
{
	public override void _Ready()
	{
		GlobalSignal signals = (GlobalSignal)GetNode("/root/GlobalSignal");
		signals.Connect(nameof(GlobalSignal.BulletFired), this, nameof(HandleBullet));		
	}

	public void HandleBullet(Bullet bullet, string allegiance, Vector2 position, Vector2 direction)
	{
		AddChild(bullet);
		bullet.Allegiance = allegiance;
		bullet.GlobalPosition = position;
		bullet.SetDirection(direction);
	}
}

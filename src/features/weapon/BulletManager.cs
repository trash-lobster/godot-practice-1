using Godot;

public class BulletManager : Node
{
	public override void _Ready()
	{
		GlobalSignal signals = (GlobalSignal) GetNode("/root/GlobalSignal");
		signals.Connect("BulletFired", this, nameof(HandleBullet));
	}

	public void HandleBullet(Bullet bullet, Allegiance allegiance, Vector2 position, Vector2 direction)
	{
		AddChild(bullet);
		bullet.Allegiance = allegiance;
		bullet.GlobalPosition = position;
		bullet.SetDirection(direction);
	}
}

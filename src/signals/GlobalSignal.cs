using Godot;

public class GlobalSignal : Node
{
	[Signal]
	public delegate void BulletFired(Bullet bullet, Vector2 position, Vector2 direction);
}

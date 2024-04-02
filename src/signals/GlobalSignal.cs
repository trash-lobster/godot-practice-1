using Godot;

public class GlobalSignal : Node
{
	[Signal]
	public delegate void BulletFired(Bullet bullet, Allegiance allegiance, Vector2 position, Vector2 direction);
}

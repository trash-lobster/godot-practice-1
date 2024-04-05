using Godot;

public class GlobalSignal : Node
{
	[Signal]
	public delegate void BulletFired(Bullet bullet, string allegiance, Vector2 position, Vector2 direction);
	[Signal]
	public delegate void Hit(HittableEntity entity, string allegiance);
	[Signal]
	public delegate void SetEnemyTarget(Vector2 position);
}

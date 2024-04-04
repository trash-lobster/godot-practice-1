using Godot;

public class CollisionManager : Node
{
	public override void _Ready()
	{
		GlobalSignal signals = (GlobalSignal) GetNode("/root/GlobalSignal");
		signals.Connect(nameof(GlobalSignal.Hit), this, nameof(HandleCollision));
	}

	public void HandleCollision(HittableEntity entity, string allegiance)
	{
		if (entity.Allegiance != allegiance && entity.Allegiance != "neutral")
		{
			entity.QueueFree();
		}
	}
}

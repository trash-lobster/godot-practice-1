using System;
using Godot;

public class Main : Node2D
{
	public override void _Ready()
	{
		for (int i = 0; i < 5; i++)
		{
			GenerateEnemy();
		}
	}

	public void GenerateEnemy()
	{
		var screenSize = GetViewport().GetVisibleRect().Size;
		Random random = new Random();
		var enemy = (Node2D) ResourceLoader.Load<PackedScene>("res://src//features//entities//enemy//Enemy.tscn").Instance();
		AddChild(enemy);
		Vector2 position = Vector2.Zero;
		position.x = random.Next(0, (int) screenSize.x);
		position.y = random.Next(0, (int) screenSize.y);
		enemy.GlobalPosition = position;
	}
}

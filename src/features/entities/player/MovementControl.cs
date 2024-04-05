using System;
using Godot;

public class PlayerMovementControl : Node
{
	public Vector2 Velocity { get; set; }
	public int Speed { get; set; } = 300;
	public Action<Vector2> UpdateDirection;
	public BaseMovementDirectionComponent InputComponent;

	public override void _Ready()
	{
		InputComponent = new InputDirectionComponent();
		AddChild(InputComponent);
	}

	public override void _Process(float delta)
	{
		Velocity = Vector2.Zero;
		var inputDirection = InputComponent.GetMovementDirection();
		Velocity = inputDirection * Speed;

		UpdateDirection(inputDirection);
	}
}

extends Node

signal set_movement_direction(direction)

var velocity = Vector2()
var speed : int = 300

func _process(delta: float) -> void:	
	velocity = Vector2.ZERO
	var input_direction = Input.get_vector("move_left", "move_right", "move_up", "move_down")
	velocity = input_direction * speed

	emit_signal("set_movement_direction", velocity)

func _set_speed(value : int):
	speed = value

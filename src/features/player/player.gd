extends KinematicBody2D

export (int) var speed = 300
export (Vector2) var movement_direction
onready var movement_control = $"movement-control"

func _ready():
	movement_control.connect("set_movement_direction", self, "get_movement_direction")
	movement_control._set_speed(speed)

func _physics_process(delta: float) -> void:
	look_at(get_global_mouse_position())
	move_and_slide(movement_direction * speed)

func get_movement_direction(direction : Vector2):
	movement_direction = direction.normalized()

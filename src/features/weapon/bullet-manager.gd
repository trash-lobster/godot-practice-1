extends Node

func _ready() -> void:
	# connect signals
	GlobalSignals.connect("bullet_fired", self, "handle_bullet")                        

func handle_bullet(bullet, position : Vector2, direction: Vector2):
	add_child(bullet)  
	bullet.global_position = position
	bullet.set_direction(direction)

extends Node2D

signal shoot_bullet(position)

onready var cooldown = $"attack-cooldown"

export (PackedScene) var Bullet

func _process(delta):
	get_input();

func get_input():
	if Input.is_action_pressed("shoot") && Engine.get_idle_frames() % 5 == 0:
		shoot()

func shoot():
	if (cooldown.is_stopped()):
		var bullet = Bullet.instance()
		var direction = global_position.normalized()
		# emit signal to generate bullet
		
		GlobalSignals.emit_signal("bullet_fired", bullet, global_position)
		print("shooting!")
		cooldown.start()

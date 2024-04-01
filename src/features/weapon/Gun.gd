extends Node2D

const BulletResource = preload("res://Bullet.tscn")
onready var attack_cooldown = $AttackCooldown

func _process(delta):
	get_input();

func get_input():
	if Input.is_action_pressed("shoot") && Engine.get_idle_frames() % 5 == 0:
		shoot(global_position)

func shoot(global_position: Vector2):
	# pass in a direction to shoot at
	# the bullet will naturally move at the direction
	
	# emit signal to generate bullet
	
	var bullet = BulletResource.instance()
	bullet.velocity = global_position
	self.add_child(bullet)
	

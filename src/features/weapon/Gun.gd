extends Node2D

onready var cooldown = $AttackCooldown
onready var gunTip = $GunTip

export (PackedScene) var Bullet

func _process(delta):
	if Input.is_action_pressed("shoot"):
		shoot()

func shoot():
	if (cooldown.is_stopped()):
		var bullet = Bullet.instance()
		var direction = (gunTip.global_position - global_position).normalized()
		# emit signal to generate bullet
		GlobalSignals.emit_signal("bullet_fired", bullet, gunTip.global_position, direction)
		cooldown.start()

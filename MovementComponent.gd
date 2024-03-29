extends Area2D

signal hit

export var speed = 300
export var rotation_speed = 6

var screen_size
var velocity = Vector2()
var rotation_dir = 0

func _ready():
	screen_size = get_viewport_rect().size

func _physics_process(delta):
	get_input()
	rotation += rotation_dir * rotation_speed * delta
	#velocity = move_and_slide(velocity)
	position += velocity * delta
	position.x = clamp(position.x, 0, screen_size.x)
	position.y = clamp(position.y, 0, screen_size.y)

func get_input():
	rotation_dir = 0
	velocity = Vector2()
	if Input.is_action_pressed("move_right"):
		rotation_dir += 1
	if Input.is_action_pressed("move_left"):
		rotation_dir -= 1
	if Input.is_action_pressed("move_down"):
		velocity = Vector2(-speed, 0).rotated(rotation)
	if Input.is_action_pressed("move_up"):
		velocity = Vector2(speed, 0).rotated(rotation)

func _on_Area2D_body_entered(body):
	hide() # Player disappears after being hit.
	emit_signal("hit")
	$CollisionShape2D.set_deferred("disabled", true)

func start(pos):
	position = pos
	show()
	$CollisionShape2D.disabled = false

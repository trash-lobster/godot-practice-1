class_name Bullet

extends Area2D

export (int) var speed = 10
var direction := Vector2.ZERO
var timer = 0
var rotation_dir = 0
var rotation_speed = 300
var velocity = Vector2()

func _physics_process(delta):
	rotation += rotation_dir * rotation_speed * delta
	position += velocity * delta

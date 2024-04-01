extends Node

const BulletResource = preload("res://src//features//weapon//Bullet.tscn")

func shoot(position : Vector2):
	var bullet = BulletResource.instance()
	bullet.velocity = position
	self.add_child(bullet)

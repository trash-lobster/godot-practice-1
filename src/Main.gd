extends Node2D

onready var weaponManager = $"weapon-manager" 

func _ready() -> void:
	# connect signals
	GlobalSignals.connect("bullet_fired", weaponManager, "shoot")                                       

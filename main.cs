using Godot;
using System;

public class main : Node2D
{
	PackedScene shape1;
	int incrementTick = 0;
	
	public override void _Ready()
	{
		// this should add the one of the shape variants, should add them to an array?
		shape1 = (PackedScene)GD.Load("res://Geometry1.tscn");
		Node2D geometry1 = (Node2D)shape1.Instance();
		geometry1.Position =new Vector2(0,0);
		this.AddChild(geometry1);     
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if(@event is InputEventMouseButton mouseEvent){
			GD.Print("reached mouse");   
		}
	}
	
	
	private void _on_Timer_timeout()
	{
		//Put in message to test the timer, can remove later
		GD.Print("It ticked!! Tick Number: " + incrementTick);
		incrementTick++;
		// Replace with function body.
	}

}

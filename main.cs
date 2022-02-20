using Godot;
using System;

public class main : Node2D
{
	// Loading the geometry scene into main, I think it's the same as adding a child node in Godot
	static PackedScene shape1 = (PackedScene)GD.Load("res://Geometry1.tscn");
	static PackedScene shape2 = (PackedScene)GD.Load("res://Geometry2.tscn");

	// the active shape piece that will be moved around
	Node2D geo;

	PackedScene[] geometries = new PackedScene[2] {shape1,shape2};

	float distanceX = 450;
	float distanceY = 0;
	int incrementTick = 0;
	float limit = 500;
	float maxLimit = 500;
	int row = 0;
	
	public override void _Ready()
	{
		geo =(Node2D)geometries[0].Instance();
		geo.Position =new Vector2(450,0);
		geo.Call("activate");

		//GD.Print("It tickedagain!! Tick Number: " + incrementTick);

		this.AddChild(geo); 
 
	}

// This is basically for touching the window on the mouse I think
	public override void _UnhandledInput(InputEvent @event)
	{
		if(@event is InputEventMouseButton mouseEvent){
			GD.Print("reached mouse");   
			//geo.Call("moving", incrementTick);

		}
	}
	
	
	private void _on_Timer_timeout()
	{
		//Put in message to test the timer, can remove later
		//GD.Print("It ticked!! Tick Number: " + incrementTick);
		incrementTick++;
		
		// keep track of distanced traveled using the timer
		if(distanceY <= limit){
			distanceY = incrementTick * 15;
			geo.Position = new Vector2(distanceX,distanceY);

		} else {
			geo.Call("deactivate");
			geo =(Node2D)geometries[0].Instance();
			geo.Call("activate");
			distanceX = 450;
			distanceY = 0;
			incrementTick = 0;
			limit = maxLimit;

			geo.Position = new Vector2(distanceX,distanceY);
			this.AddChild(geo);
			
		}
			
		// Replace with function body.
	}
	
	// adding moving to the main in order to use the timer to change the movement accordingly.
	 public override void _Process(float delta)
 {
	 if(Input.IsKeyPressed((int)KeyList.A)){
		 		 GD.Print(distanceX);

		 if(distanceX > 450 && distanceX <= 630){
			distanceX -= 1;
			geo.Call("left", distanceX, distanceY);
		 }
		 
	 }
	 if(Input.IsKeyPressed((int)KeyList.D)){
		 GD.Print(distanceX);
		  if(distanceX >= 450 && distanceX < 630){
			distanceX += 1;
			geo.Call("right", distanceX, distanceY);
		 }
	 }

	 if(Input.IsKeyPressed((int)KeyList.Space)){
		limit-= 50;
	 }
	
	/*if(Input.IsKeyPressed((int)KeyList.S)){
		$Timer.set_wait_time(0.5f);
	}
	else{
		$Timer.set_wait_time(1f);
	}*/

 }

}

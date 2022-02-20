using Godot;
using System;

public class geo : Node2D
{
	bool isActive = false;

	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public void moveY(float steps){
		//GD.Print("methods is working");
		this.Position += new Vector2(0,steps);

	}

	public void activate(){
		isActive = true;
	}
	public void deactivate(){
		isActive = false;
	}

	public void left(float distanceX, float distanceY){
		 	this.Position = new Vector2(distanceX, distanceY);
	}
	public void right(float distanceX, float distanceY){
		this.Position = new Vector2(distanceX, distanceY);
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
	float R = 0.1f;

	if(Input.IsKeyPressed((int)KeyList.W) && isActive){
		 this.Rotate(R);
	 }

 }
}

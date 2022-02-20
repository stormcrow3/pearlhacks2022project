using Godot;
using System;

public class Block : Sprite
{
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
     float DISTANCE = 5;
     float R = 0.5f;
     if(Input.IsKeyPressed((int)KeyList.A)){
         this.Position -= new Vector2(DISTANCE,0);
     }
     if(Input.IsKeyPressed((int)KeyList.D)){
         this.Position += new Vector2(DISTANCE,0);
     }
     if(Input.IsKeyPressed((int)KeyList.W)){
         this.Rotate(R);
     }
 }
}

using Godot;
using System;

public partial class Spawner : Node2D
{
	float speed = 190;

	[Export]
	public float leftBound = 340f;

    [Export]
    public float rightBound = 800f;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CustomMove(delta);
	}

	void CustomMove(double delta)
	{
		Translate(new Vector2(speed * (float)delta, 0));

		if (Position.X > rightBound)
		{
			speed = -(Math.Abs(speed));
		}

        if (Position.X < leftBound)
		{
			speed = Math.Abs(speed);
		}
    }
}

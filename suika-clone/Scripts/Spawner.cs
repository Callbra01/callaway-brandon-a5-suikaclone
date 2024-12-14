using Godot;
using System;

public partial class Spawner : Node2D
{
	float speed = 190;

	[Export]
	public float leftBound = 340f;

    [Export]
    public float rightBound = 800f;

	[Export]
	public PackedScene cherry;

	[Export]
	public Node2D fruitParent;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CustomMove(delta);

		if (Input.IsActionJustPressed("spawn"))
		{
			RigidBody2D fruit = cherry.Instantiate<RigidBody2D>();
			fruitParent.AddChild(fruit);
			fruit.GlobalPosition = this.GlobalPosition;
			if (fruit.Position.Y > GetViewport().GetVisibleRect().Size.Y - 200)
			{
				fruit.QueueFree();
			}
		}
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

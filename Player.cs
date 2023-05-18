using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public new const float Speed = 300.0f;
    public new const float JumpVelocity = -400.0f;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public new float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    private AnimationPlayer _animationPlayer;

    private Sprite2D _sprite;

    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _sprite = GetNode<Sprite2D>("Sprite");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
            velocity.Y += gravity * (float)delta;

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
            velocity.Y = JumpVelocity;

        
        if (Input.IsActionPressed("left")) 
        {
            _sprite.FlipH = true;
            _animationPlayer.Play("walking");
            velocity.X = -Speed;
        }
        else if (Input.IsActionPressed("right"))
        {
            _sprite.FlipH = false;
            _animationPlayer.Play("walking");
            velocity.X = Speed;
        } else 
        {
            _animationPlayer.Play("idle");
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}

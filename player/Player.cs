using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public new const float Speed = 300.0f;
    public new const float JumpVelocity = -400.0f;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public new float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    private PlayerState _state;

    private AnimationPlayer _animationPlayer;

    private Sprite2D _sprite;

    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _sprite = GetNode<Sprite2D>("Sprite");
        SetNewState(new PlayerStateIdle(this));
    }

    public void SetNewState(PlayerState newState)
    {
        _state = newState;
    }

    public override void _PhysicsProcess(double delta)
    {
        _state._PhysicsProcess(delta);
    }
}
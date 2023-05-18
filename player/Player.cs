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

    private Timer _timer;

    private bool _canHide;

    public override void _Ready()
    {
        _canHide = true;
    
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _timer = GetNode<Timer>("Timer");
        SetNewState(new PlayerStateIdle(this));
    }

    
    public bool CanHide() 
    {
        return _canHide;
    }

    public void SetNewState(PlayerState newState)
    {
        _state?.Dispose();

        if (newState is PlayerStateHiding) 
        {
            _canHide = false;
            _timer.Start();

            _timer.Timeout += _on_Timer_timeout;
            
        } 
        
        
        _state = newState;
    }

    public override void _PhysicsProcess(double delta)
    {
        _state?._PhysicsProcess(delta);
    }

    
    private bool isState(Type type)
    {
        return _state.GetType() == type;
    }

    private void _on_Timer_timeout()
    {
        _canHide = true;
        _timer.Timeout -= _on_Timer_timeout;
    }

    
}
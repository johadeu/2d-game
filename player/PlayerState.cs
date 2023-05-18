using System;
using Godot;

public abstract class PlayerState : IDisposable
{

    protected AnimationPlayer _animationPlayer;
    protected Node2D _spriteContainer;
    protected Player _player;

    public PlayerState(Player player)
    {
        _player = player;
        _animationPlayer = player.GetNode<AnimationPlayer>("AnimationPlayer");
        _spriteContainer = player.GetNode<Node2D>("Sprites");
    }

    public virtual void Dispose() 
    {
        
    }
    public abstract void _PhysicsProcess(double delta);
}
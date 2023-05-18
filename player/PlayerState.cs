using Godot;

public abstract class PlayerState 
{

    protected AnimationPlayer _animationPlayer;
    protected Sprite2D _sprite;
    protected Player _player;

    public PlayerState(Player player)
    {
        _player = player;
        _animationPlayer = player.GetNode<AnimationPlayer>("AnimationPlayer");
        _sprite = player.GetNode<Sprite2D>("Sprite");
    }

    public abstract void _PhysicsProcess(double delta);
}
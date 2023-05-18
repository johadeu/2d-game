using Godot;

public class PlayerStateWalking : PlayerState
{
    public PlayerStateWalking(Player player, int direction) : base(player)
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = _player.Velocity;
        _sprite.FlipH = true;
        _animationPlayer.Play("walking", -1, 2);
        velocity.X = -Player.Speed;

        

    }
}
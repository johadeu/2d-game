using Godot;

public class PlayerStateWalking : PlayerState
{
    private int _direction;
    
    public PlayerStateWalking(Player player, int direction) : base(player)
    {
        _direction = direction;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("down") && _player.CanHide())
        {
            _player.SetNewState(new PlayerStateHiding(_player));
        } else if (Input.IsActionJustPressed("left")  && _direction > 0) 
        {
            _player.SetNewState(new PlayerStateWalking(_player, -1));
        } else if (Input.IsActionJustPressed("right") && _direction < 0) 
        {
            _player.SetNewState(new PlayerStateWalking(_player, 1));
        }
        else if (Input.IsActionJustReleased("left") && _direction < 0 || Input.IsActionJustReleased("right")  && _direction > 0)
        {
            _player.SetNewState(new PlayerStateIdle(_player));
        } else
        {
            Vector2 velocity = _player.Velocity;
            _spriteContainer.Scale = new Vector2(_direction, 1);
            _animationPlayer.Play("walking", -1, 2);
            velocity.X = Player.Speed * _direction;

            _player.Velocity = velocity;
            _player.MoveAndSlide();
        }
    }
}
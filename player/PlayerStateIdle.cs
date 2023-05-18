using Godot;

public class PlayerStateIdle : PlayerState
{

    public PlayerStateIdle(Player player) : base(player)
    {
        _animationPlayer.Play("idle", -1, 1f);

        var rnd = new RandomNumberGenerator();

        _animationPlayer.AnimationFinished += _on_AnimationPlayer_animation_finished;
    }

    public override void Dispose()
    {
        _animationPlayer.AnimationFinished -= _on_AnimationPlayer_animation_finished;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("down") && _player.CanHide())
        {
            _player.SetNewState(new PlayerStateHiding(_player));
        }
        else if (Input.IsActionJustPressed("left") || Input.IsActionJustPressed("right"))
        {
            _player.SetNewState(new PlayerStateWalking(_player, Input.IsActionJustPressed("left") ? -1 : 1));
        }
    }

    private void _on_AnimationPlayer_animation_finished(StringName anim_name)
    {
        var rnd = new RandomNumberGenerator();

        var randomAnimation = rnd.Randf();

        if (randomAnimation > 0.7f)
        {
            _animationPlayer.Play("idle_blinking", -1, 1f);
        }
        else
        {
            _animationPlayer.Play("idle", -1, 1f);
        }
    }
}
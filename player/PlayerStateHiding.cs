using Godot;

public class PlayerStateHiding : PlayerState
{
    public PlayerStateHiding(Player player) : base(player)
    {
        _animationPlayer.Play("hiding", -1, 1f);   
        
        _animationPlayer.AnimationFinished += _on_AnimationPlayer_animation_finished;
    }

    public override void Dispose()
    {
        _animationPlayer.AnimationFinished -= _on_AnimationPlayer_animation_finished;
    }

    public override void _PhysicsProcess(double delta)
    {
    
    }

    private void _on_AnimationPlayer_animation_finished(StringName anim_name)
    {
        if (anim_name == "hiding")
        {
            _animationPlayer.Play("defending", -1, 1f);
        } else if (Input.IsActionPressed("left") || Input.IsActionPressed("right")) 
        {
            _player.SetNewState(new PlayerStateWalking(_player, Input.IsActionPressed("left") ? -1 : 1));
        } else
        {
            _player.SetNewState(new PlayerStateIdle(_player));    
        }
    }
}
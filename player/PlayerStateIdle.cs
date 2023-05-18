using Godot;

public class PlayerStateIdle : PlayerState
{

    public PlayerStateIdle(Player player) : base(player)
    {
        _animationPlayer.Play("idle", -1, 1f);

        var rnd = new RandomNumberGenerator();

        _animationPlayer.AnimationFinished += (StringName animationName) =>
        {
            var randomAnimation = rnd.Randf();

            if (randomAnimation > 0.7f)
            {
                _animationPlayer.Play("idle_blinking", -1, 1f);
            }
            else
            {
                _animationPlayer.Play("idle", -1, 1f);
            }
        };
    }

    public override void _PhysicsProcess(double delta)
    {
    }
}
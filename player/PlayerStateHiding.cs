public class PlayerStateHiding : PlayerState
{
    public PlayerStateHiding(Player player) : base(player)
    {
        _animationPlayer.Play("hiding", -1, 1f);   
    }
    
    public override void _PhysicsProcess(double delta)
    {
        
    }
}
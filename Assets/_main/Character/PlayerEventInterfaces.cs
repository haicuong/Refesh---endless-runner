public struct PlayerOnDamage : IEvent { }
public struct PlayerOnJump : IEvent { }
public struct PlayerOnDead : IEvent { }
public struct PlayerOnGround : IEvent { }
public struct PlayerLeaveGround : IEvent { }
public struct PLayerOnHealthChange : IEvent
{
    public PLayerOnHealthChange(float health)
    {
        this.health = health;
    }
    public readonly float health;
}
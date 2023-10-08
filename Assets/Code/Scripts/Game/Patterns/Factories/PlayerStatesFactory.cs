namespace ProjectPK.Patterns.Factories
{
    using ProjectPK.Player.Manager.Contexts;
    using ProjectPK.Player.Manager.States;
    using VUDK.Patterns.StateMachine;

    public static class PlayerStatesFactory
    {
        public static State<PlayerContext> Create(PlayerStateKey stateKey, StateMachine relatedStateMachine, PlayerContext context)
        {
            switch (stateKey)
            {
                case PlayerStateKey.Ground:
                    return new PlayerGroundState(relatedStateMachine, context);

                case PlayerStateKey.Jump:
                    return new PlayerJumpState(relatedStateMachine, context);

                case PlayerStateKey.Air:
                    return new PlayerAirState(relatedStateMachine, context);
            }

            return null;
        }
    }
}
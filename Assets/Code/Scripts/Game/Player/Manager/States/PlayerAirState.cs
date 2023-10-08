namespace ProjectPK.Player.Manager.States
{
    using VUDK.Patterns.StateMachine;
    using ProjectPK.Player.Manager.Contexts;

    public class PlayerAirState : State<PlayerContext>
    {
        public PlayerAirState(StateMachine relatedStateMachine, Context context) : base(relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            Context.Graphics.AnimateIsJumping(false);
        }

        public override void PhysicsProcess()
        {
        }

        public override void Process()
        {
            if (Context.PlayerMovement.IsGrounded)
                ChangeState(PlayerStateKey.Ground);
        }
    }
}
namespace ProjectPK.Player.Manager.States
{
    using VUDK.Patterns.StateMachine;
    using ProjectPK.Player.Manager.Contexts;
    using System;

    public class PlayerAirState : State<PlayerContext>
    {
        public PlayerAirState(Enum stateKey, StateMachine relatedStateMachine, Context context) : base(stateKey, relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            Context.Graphics.AnimateIsJumping(false);
        }

        public override void FixedProcess()
        {
        }

        public override void Process()
        {
            if (Context.PlayerMovement.IsGrounded)
                ChangeState(PlayerStateKey.Ground);
        }
    }
}
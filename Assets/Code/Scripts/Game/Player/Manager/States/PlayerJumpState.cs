namespace ProjectPK.Player.Manager.States
{
    using UnityEngine;
    using VUDK.Patterns.StateMachine;
    using ProjectPK.Player.Manager.Contexts;

    public class PlayerJumpState : State<PlayerContext>
    {
        public PlayerJumpState(StateMachine relatedStateMachine, Context context) : base(relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
            Context.PlayerMovement.Jump(Vector3.up);
            Context.Graphics.AnimateIsJumping(true);
            ChangeState(PlayerStateKey.Air);
        }

        public override void Exit()
        {
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
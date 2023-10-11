namespace ProjectPK.Player.Manager.States
{
    using UnityEngine;
    using VUDK.Patterns.StateMachine;
    using ProjectPK.Player.Manager.Contexts;
    using System;

    public class PlayerGroundState : State<PlayerContext>
    {
        public PlayerGroundState(Enum stateKey, StateMachine relatedStateMachine, Context context) : base(stateKey, relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
            Context.MovementInput.OnInputDirection += ChangeToJump;
        }

        public override void Exit()
        {
            Context.MovementInput.OnInputDirection -= ChangeToJump;
        }

        public override void FixedProcess()
        {
        }

        public override void Process()
        {
            Context.Graphics.AnimateMovement(Context.PlayerMovement.InputMove);

            if (!Context.PlayerMovement.IsGrounded)
                ChangeState(PlayerStateKey.Air);
        }

        private void ChangeToJump(Vector2 direction)
        {
            if (direction.y >= Context.PlayerMovement.InputJumpRange)
                ChangeState(PlayerStateKey.Jump);
        }
    }
}
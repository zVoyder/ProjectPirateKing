namespace ProjectPK.Player.Manager.States
{
    using VUDK.Patterns.StateMachine;
    using ProjectPK.Player.Manager.Contexts;
    using UnityEngine;

    public class PlayerGroundState : State<PlayerContext>
    {
        public PlayerGroundState(StateMachine relatedStateMachine, Context context) : base(relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
            Context.Inputs.MobileDefaultControls.OnInputDirection += ChangeToJump;
        }

        public override void Exit()
        {
            Context.Inputs.MobileDefaultControls.OnInputDirection -= ChangeToJump;
        }

        public override void PhysicsProcess()
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
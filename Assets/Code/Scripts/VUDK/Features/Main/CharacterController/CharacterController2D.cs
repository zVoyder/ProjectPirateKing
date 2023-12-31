﻿namespace VUDK.Features.Main.CharacterController
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class CharacterController2D : CharacterControllerBase
    {
        protected Rigidbody2D Rigidbody;

        public override bool IsGrounded => Physics2D.OverlapCircle(transform.position + GroundedOffset, GroundedRadius, GroundLayers);

        protected virtual void Awake()
        {
            TryGetComponent(out Rigidbody);
        }

        public override void StopCharacterOnPosition()
        {
            base.StopCharacterOnPosition();
            Rigidbody.velocity = new Vector2(0f, Rigidbody.velocity.y);
        }

        public override void Jump(Vector3 direction)
        {
            if (!CanJump) return;

            base.Jump(direction);
            Rigidbody.AddForce(direction * JumpForce, ForceMode2D.Impulse);
        }

        public override void MoveCharacter(Vector2 direction)
        {
            base.MoveCharacter(direction);

            Vector2 _movementDirection = /* transform.forward * InputMove.y + */ transform.right * InputMove.x; // TO DO: Add a sub-class from this class for isometric 2d movement
            Vector2 velocityDirection = new Vector2(_movementDirection.x * CurrentSpeed, Rigidbody.velocity.y);
            Rigidbody.velocity = velocityDirection;
        }
    }
}

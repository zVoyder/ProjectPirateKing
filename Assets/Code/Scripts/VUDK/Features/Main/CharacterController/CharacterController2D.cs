namespace VUDK.Features.Main.CharacterController
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class CharacterController2D : CharacterControllerBase
    {
        protected Rigidbody2D Rigidbody;

        protected virtual void Awake()
        {
            TryGetComponent(out Rigidbody);
        }

        protected override void StopCharacterOnPosition()
        {
            base.StopCharacterOnPosition();
            Rigidbody.velocity = new Vector2(0f, Rigidbody.velocity.y);
        }

        protected override void Jump(Vector3 direction)
        {
            base.Jump(direction);
            Rigidbody.AddForce(direction * JumpForce);
        }

        protected override void MoveCharacter(Vector2 direction)
        {
            base.MoveCharacter(direction);

            Vector2 _movementDirection = /* transform.forward * InputMove.y + */ transform.right * InputMove.x; // TO DO: Add a sub-class from this class for isometric 2d movement
            Vector2 velocityDirection = new Vector2(_movementDirection.x * CurrentSpeed, Rigidbody.velocity.y);
            Rigidbody.velocity = velocityDirection;
        }
    }
}

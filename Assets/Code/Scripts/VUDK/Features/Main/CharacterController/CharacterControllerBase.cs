namespace VUDK.Features.Main.CharacterController
{
    using System;
    using UnityEngine;

    public abstract class CharacterControllerBase : MonoBehaviour
    {
        [Header("Movement")]
        public float MoveSpeed;
        public float SprintSpeed;
        public float AirSpeed;
        public float JumpForce;

        [SerializeField, Header("Ground")]
        protected Vector3 GroundedOffset;
        [SerializeField]
        protected LayerMask GroundLayers;
        [SerializeField]
        private float _groundedRadius;

        protected bool IsRunning;
        protected float CurrentSpeed;
        protected Vector2 InputMove;

        public bool IsGrounded => Physics.CheckSphere(transform.position + GroundedOffset, _groundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
        protected bool CanJump => IsGrounded;

        public event Action<Vector2> OnMovement;

        protected virtual void Update()
        {
            MoveUpdateVelocity();
        }

        /// <summary>
        /// Moves the character in the specified direction at the setted speed using rigidbody velocity.
        /// </summary>
        /// <param name="direction">Direction.</param>
        protected virtual void MoveCharacter(Vector2 direction)
        {
            InputMove = direction;
            OnMovement?.Invoke(direction);
        }

        /// <summary>
        /// Makes the character jump in the specified direction at the setted jump force using rigidbody addforce.
        /// </summary>
        /// <param name="direction">Direction.</param>
        protected virtual void Jump(Vector3 direction)
        {
            if (!CanJump)
                return;
        }

        /// <summary>
        /// Stops the character movement.
        /// </summary>
        protected void StopCharacter()
        {
            InputMove = Vector2.zero;
            StopSprint();
        }

        /// <summary>
        /// Immediately stops the character on its current position.
        /// </summary>
        protected virtual void StopCharacterOnPosition()
        {
            StopCharacter();
        }

        protected void Sprint()
        {
            IsRunning = true;
        }

        protected void StopSprint()
        {
            IsRunning = false;
        }

        private void MoveUpdateVelocity()
        {
            CurrentSpeed = IsGrounded ? (IsRunning ? SprintSpeed : MoveSpeed) : AirSpeed;
        }

#if DEBUG
        protected virtual void OnDrawGizmos()
        {
            DrawCheckGroundSphere();
        }

        private void DrawCheckGroundSphere()
        {
            Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Gizmos.DrawSphere(transform.position + GroundedOffset, _groundedRadius);
        }
#endif
    }
}
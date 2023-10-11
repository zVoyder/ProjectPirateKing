namespace ProjectPK.Player
{
    using UnityEngine;
    using ProjectPK.Player.Interfaces;
    using ProjectPK.Config.Constants;
    using ProjectPK.Player.Manager;
    using VUDK.Features.Main.InputSystem;
    using UnityEngine.InputSystem;
    using System;

    public class PlayerGraphicsController : MonoBehaviour, IPlayerComponent
    {
        [field: SerializeField, Header("Graphics")]
        public Animator Animator { get; private set; }
        [field: SerializeField]
        public SpriteRenderer Sprite { get; private set; }

        [SerializeField, Header("Flip Settings")]
        private bool _invertFlipX;

        private PlayerManager _playerManager;

        /// <summary>
        /// Initializes the graphics of the player.
        /// </summary>
        /// <param name="player"><see cref="PlayerManager"/> to initialize this Entity with.</param>
        public void Init(PlayerManager player)
        {
            _playerManager = player;
        }

        private void OnEnable()
        {
            // I don't put this in a Player State because the character MUST ALWAYS be facing the direction of the movement.
            _playerManager.Movement.OnMovement += Flip;
        }

        private void OnDisable()
        {
            _playerManager.Movement.OnMovement -= Flip;
        }

        /// <summary>
        /// Aimates the movement with a direction.
        /// </summary>
        /// <param name="direction">Direction of the movement.</param>
        public void AnimateMovement(Vector2 direction)
        {
            Animator.SetFloat(Constants.PlayerAnimations.Movement, Mathf.Abs(direction.x));
        }

        /// <summary>
        /// Animates the jumping.
        /// </summary>
        /// <param name="isJumping">Animator Controller boolean isJumping.</param>
        public void AnimateIsJumping(bool isJumping)
        {
            Animator.SetBool(Constants.PlayerAnimations.IsJumping, isJumping);
        }

        public void AnimateAttack()
        {
            Animator.SetTrigger(Constants.PlayerAnimations.Attack);
        }

        /// <summary>
        /// Flips the sprite X.
        /// </summary>
        /// <param name="direction">Facing direction.</param>
        private void Flip(Vector2 direction)
        {
            Sprite.flipX = _invertFlipX ? direction.x < 0f : direction.x > 0f;
        }
    }
}
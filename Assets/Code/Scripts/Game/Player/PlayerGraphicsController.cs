namespace ProjectPK.Player
{
    using UnityEngine;
    using ProjectPK.Player.Interfaces;
    using ProjectPK.GameConfig.Constants;
    using ProjectPK.Player.Manager;

    public class PlayerGraphicsController : MonoBehaviour, IPlayerComponent
    {
        [SerializeField, Header("Graphics")]
        private Animator _animator;
        [SerializeField]
        private SpriteRenderer _sprite;

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
            _animator.SetFloat(Constants.PlayerAnimations.Movement, Mathf.Abs(direction.x));
        }

        public void AnimateIsJumping(bool isJumping)
        {
            _animator.SetBool(Constants.PlayerAnimations.IsJumping, isJumping);
        }

        /// <summary>
        /// Flips the sprite X.
        /// </summary>
        /// <param name="direction">Facing direction.</param>
        public void Flip(Vector2 direction)
        {
            _sprite.flipX = _invertFlipX ? direction.x < 0f : direction.x > 0f;
        }
    }
}
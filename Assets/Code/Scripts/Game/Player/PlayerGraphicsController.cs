namespace ProjectPK.Player
{
    using UnityEngine;
    using ProjectPK.Constants;
    using ProjectPK.Player.Interfaces;

    public class PlayerGraphicsController : MonoBehaviour, IPlayerComponent
    {
        [SerializeField, Header("Flip Settings")]
        private bool _defaultFlipX; 

        private PlayerManager _playerManager;
        private Animator _anim;
        private SpriteRenderer _sprite;

        /// <summary>
        /// Initializes the graphics of the player.
        /// </summary>
        /// <param name="player"><see cref="PlayerManager"/> to initialize this Entity with.</param>
        public void Init(PlayerManager player)
        {
            _anim = player.Animator;
            _sprite = player.Sprite;
            _playerManager = player;
        }

        private void OnEnable()
        {
            _playerManager.Movement.OnMovement += AnimateMovement;
            //_playerManager.Entity.OnDeath += AnimateDeath;
        }

        private void OnDisable()
        {
            _playerManager.Movement.OnMovement -= AnimateMovement;
            //_playerManager.Entity.OnDeath -= AnimateDeath;
        }

        /// <summary>
        /// Aimates the movement with a direction.
        /// </summary>
        /// <param name="direction">Direction of the movement.</param>
        private void AnimateMovement(Vector2 direction)
        {
            Flip(direction.x);
            //_anim.SetFloat(AnimationConstants.s_PlayerMovement, direction);
        }

        /// <summary>
        /// Animates the death.
        /// </summary>
        //private void AnimateDeath()
        //{
        //    _anim.SetTrigger(Constants.AnimationConstants.s_PlayerDeath);
        //}

        /// <summary>
        /// Flips the sprite X.
        /// </summary>
        /// <param name="direction">Facing direction.</param>
        private void Flip(float direction)
        {
            _sprite.flipX = _defaultFlipX ? direction < 0f : direction > 0f;
        }
    }
}
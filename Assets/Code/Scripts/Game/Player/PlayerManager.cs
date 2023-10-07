namespace ProjectPK.Player
{
    using ProjectPK.Player;
    using UnityEngine;

    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerManager : MonoBehaviour
    {
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerMovement Movement { get; private set; }

        public SpriteRenderer Sprite { get; private set; }
        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }

        private void Awake()
        {
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerMovement movement);

            TryGetComponent(out SpriteRenderer sprite);
            TryGetComponent(out Animator animator);
            TryGetComponent(out Rigidbody2D rigidbody);

            Graphics = graphics;
            Movement = movement;
            Rigidbody = rigidbody;
            Sprite = sprite;
            Animator = animator;

            Graphics.Init(this);
            Movement.Init(this);
        }
    }
}
namespace VUDK.Generic.Managers.GameManager
{
    using UnityEngine;
    using VUDK.Features.Main.EventsSystem;
    using VUDK.Patterns.ObjectPool;

    public class GameState : MonoBehaviour
    {
        [field: SerializeField, Header("Event Manager")]
        public EventManager EventManager { get; private set; }

        [field: SerializeField, Header("Pooling")]
        public PoolsManager PoolsManager { get; private set; }
    }
}
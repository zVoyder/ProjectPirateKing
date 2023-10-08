namespace VUDK.Generic.Managers.GameManagers
{
    using UnityEngine;
    using VUDK.Patterns.ObjectPool;

    public class GameManager : MonoBehaviour
    {
        [field: SerializeField, Header("Pooling")]
        public PoolsManager PoolsManager { get; private set; }
    }
}
namespace VUDK.Generic.Managers.GameManagers
{
    using UnityEngine;
    using VUDK.Patterns.Singleton;

    /// <summary>
    /// Managers Structure:
    /// MainManager: Serves as the central hub for primary managers.
    /// - GameManager: Orchestrates game-specific managers for precise game control; extensible.
    /// - EventManager: Governs all in-game events, providing centralized event handling; extensible.
    /// - GameState: Manages the game's state through a versatile state machine; extensible.
    /// </summary>
    [DefaultExecutionOrder(-999)]
    public sealed class MainManager : Singleton<MainManager>
    {
        [field: SerializeField, Header("Game Manager")]
        public GameManager GameManager{ get; private set; }

        [field: SerializeField, Header("Event Manager")]
        public EventManager EventManager { get; private set; }
    }
}

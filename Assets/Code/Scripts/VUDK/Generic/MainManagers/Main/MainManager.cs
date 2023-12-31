﻿namespace VUDK.Generic.Managers.Main
{
    using UnityEngine;
    using VUDK.Patterns.Singleton;

    /// <summary>
    /// Managers Structure:
    /// MainManager: Serves as the central hub for primary managers.
    /// Extensible managers:
    /// - GameManager: Orchestrates game-specific managers for precise game control; extensible.
    /// - EventManager: Governs all in-game events, providing centralized event handling; extensible.
    /// - GameStateMachine: Manages the game's state through a versatile state machine; extensible.
    /// Not extensible managers:
    /// - GameConfig: Manages all the possible game's configurations; not extensible.
    /// </summary>
    [DefaultExecutionOrder(-999)]
    public sealed class MainManager : Singleton<MainManager>
    {
        [field: SerializeField, Header("Game Manager")]
        public GameManager GameManager;
        [field: SerializeField, Header("Event Manager")]
        public EventManager EventManager;
        [field: SerializeField, Header("Game Config")]
        public GameConfig GameConfig { get; private set; }
        [field: SerializeField, Header("Game State Machine")]
        public GameStateMachine GameStateMachine { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            GameStateMachine.Init();
        }

        private void OnValidate()
        {
            if (GameManager == null)
                Debug.LogError("GameManager missing reference.");

            if (EventManager == null)
                Debug.LogError("EventManager missing reference.");

            if (GameConfig == null)
                Debug.LogError("GameConfig missing reference.");

            if (GameStateMachine == null)
                Debug.LogError("GameStateMachine missing reference.");
        }
    }
}

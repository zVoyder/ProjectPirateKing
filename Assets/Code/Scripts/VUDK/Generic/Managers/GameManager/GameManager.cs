namespace VUDK.Generic.Managers.GameManager
{
    using ProjectPK.Managers;
    using System;
    using UnityEngine;
    using VUDK.Patterns.Singleton;
    using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

    /// <summary>
    /// GameManager: Contains all the MAIN Managers that can be extended.
    /// - GameState: Main Manager that contains all the Managers for the specific game.
    /// - GameMode: (TO DO: Possible next main manager feature) 
    /// </summary>
    public static class GameManager
    {
        public static GameState GameState{ get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void LoadGameManager()
        {
            GameState = GameObject.FindFirstObjectByType<GameState>();
        }
    }
}

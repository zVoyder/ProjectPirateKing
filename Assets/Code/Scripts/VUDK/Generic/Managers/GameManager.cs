namespace VUDK.Generic.Managers
{
    using UnityEngine;
    using VUDK.Features.Main.DialogueSystem;
    using VUDK.Features.Main.EventsSystem;
    using VUDK.Features.Main.VoiceRecognition;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.Singleton;

    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField, Header("Pooling")]
        public PoolsManager PoolsManager { get; private set; }

        [field: SerializeField, Header("Dialogue")]
        public DialogueManager DialogueManager { get; private set; }
        
        [field: SerializeField, Header("Voice Recognizer")]
        public VoiceEventRecognizer VoiceEventRecognizer { get; private set; }

        [field: SerializeField, Header("Event Manager")]
        public EventManager EventManager { get; private set; }
    }
}
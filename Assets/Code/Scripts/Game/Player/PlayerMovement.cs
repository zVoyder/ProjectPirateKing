namespace ProjectPK.Player
{
    using UnityEngine;
    using VUDK.Features.Main.CharacterController;
    using VUDK.Generic.Managers.GameManagers;
    using VUDK.Generic.Managers.GameManagers.Interfaces;
    using ProjectPK.Player.Manager;
    using ProjectPK.Managers;
    using ProjectPK.Player.Interfaces;

    public class PlayerMovement : CharacterController2D, IPlayerComponent, ICastGameManager<PKGameManager>
    {
        [field: SerializeField, Range(0f, 1f), Header("Jump Input Range")]
        public float InputJumpRange { get; private set; }

        public PKGameManager GameManager => (PKGameManager)MainManager.Instance.GameManager;

        public void Init(PlayerManager player)
        {
        }

        private void OnEnable()
        {
            GameManager.MobileInputsManager.MobileDefaultControls.OnInputDirection += MoveCharacter;
            GameManager.MobileInputsManager.MobileDefaultControls.OnInputCancelled += StopCharacterOnPosition;
            GameManager.MobileInputsManager.MobileDefaultControls.OnInputInvalid += StopCharacterOnPosition;
        }

        private void OnDisable()
        {
            GameManager.MobileInputsManager.MobileDefaultControls.OnInputDirection -= MoveCharacter;
            GameManager.MobileInputsManager.MobileDefaultControls.OnInputCancelled -= StopCharacterOnPosition;
            GameManager.MobileInputsManager.MobileDefaultControls.OnInputInvalid -= StopCharacterOnPosition;
        }
    }
}

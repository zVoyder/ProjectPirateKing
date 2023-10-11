namespace ProjectPK.Player
{
    using UnityEngine;
    using VUDK.Features.Main.CharacterController;
    using VUDK.Features.Main.Inputs.MobileInputs.Keys;
    using ProjectPK.Player.Manager;
    using ProjectPK.Player.Interfaces;
    using VUDK.Features.Main.Inputs.MobileInputs.MobileInputActions.Interfaces;
    using VUDK.Features.Main.InputSystem.MobileInputs;

    public class PlayerMovement : CharacterController2D, IPlayerComponent, ICastMobileInput<MobileAnalog>
    {
        private PlayerManager _playerManager;

        [field: SerializeField, Range(0f, 1f), Header("Jump Input Range")]
        public float InputJumpRange { get; private set; }
        public MobileAnalog InputTouch => _playerManager.GameManager.MobileInputsManager.MobileInputsActions[MobileInputActionKeys.Pad] as MobileAnalog;

        public void Init(PlayerManager player)
        {
            _playerManager = player;
        }

        private void OnEnable()
        {
            InputTouch.OnInputDirection += MoveCharacter;
            InputTouch.OnInputCancelled += StopCharacterOnPosition;
            InputTouch.OnInputInvalid += StopCharacterOnPosition;
        }

        private void OnDisable()
        {
            InputTouch.OnInputDirection -= MoveCharacter;
            InputTouch.OnInputCancelled -= StopCharacterOnPosition;
            InputTouch.OnInputInvalid -= StopCharacterOnPosition;
        }
    }
}

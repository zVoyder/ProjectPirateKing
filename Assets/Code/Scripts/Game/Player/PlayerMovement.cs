namespace ProjectPK.Player
{
    using VUDK.Features.Main.CharacterController;
    using VUDK.Generic.Managers.GameManager;
    using VUDK.Generic.Managers.GameManager.Interfaces;
    using ProjectPK.Player.Interfaces;
    using ProjectPK.Managers;

    public class PlayerMovement : CharacterController2D, IPlayerComponent, ICastGameState<PKGameState>
    {
        public PKGameState CastedGameState => (PKGameState)GameManager.GameState;

        public void Init(PlayerManager player)
        {
            Rigidbody = player.Rigidbody;
        }

        protected override void Awake()
        {
        }

        private void OnEnable()
        {
            CastedGameState.MobileInputsManager.MobileDefaultControls.OnInputDirection += MoveCharacter;
            CastedGameState.MobileInputsManager.MobileDefaultControls.OnInputCancelled += StopCharacterOnPosition;
        }

        private void OnDisable()
        {
            CastedGameState.MobileInputsManager.MobileDefaultControls.OnInputDirection -= MoveCharacter;
            CastedGameState.MobileInputsManager.MobileDefaultControls.OnInputCancelled -= StopCharacterOnPosition;
        }
    }
}

namespace ProjectPK.Player.Manager.Contexts
{
    using VUDK.Features.Main.Inputs.MobileInputs.Keys;
    using VUDK.Features.Main.Inputs.MobileInputs.MobileInputActions.Interfaces;
    using VUDK.Features.Main.InputSystem.MobileInputs;
    using VUDK.Features.Main.InputSysten.MobileInputs;
    using VUDK.Patterns.StateMachine;

    public class PlayerContext : Context
    {
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerMovement PlayerMovement { get; private set; }
        public MobileInputsManager Inputs { get; private set; }

        public MobileAnalog MovementInput => Inputs.MobileInputsActions[MobileInputActionKeys.Pad] as MobileAnalog;

        public PlayerContext(MobileInputsManager inputs, PlayerMovement playerMovement, PlayerGraphicsController graphics)
        {
            PlayerMovement = playerMovement;
            Graphics = graphics;
            Inputs = inputs;
        }
    }
}

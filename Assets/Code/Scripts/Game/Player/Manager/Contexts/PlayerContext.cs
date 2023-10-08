namespace ProjectPK.Player.Manager.Contexts
{
    using VUDK.Features.Main.InputSysten.MobileInputs;
    using VUDK.Patterns.StateMachine;

    public class PlayerContext : Context
    {
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerMovement PlayerMovement { get; private set; }
        public MobileInputsManager Inputs { get; private set; }

        public PlayerContext(MobileInputsManager inputs, PlayerMovement playerMovement, PlayerGraphicsController graphics)
        {
            PlayerMovement = playerMovement;
            Graphics = graphics;
            Inputs = inputs;
        }
    }
}

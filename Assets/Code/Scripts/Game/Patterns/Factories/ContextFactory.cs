namespace ProjectPK.Patterns.Factories
{
    using ProjectPK.Player;
    using ProjectPK.Player.Manager.Contexts;
    using VUDK.Features.Main.InputSysten.MobileInputs;

    public static class ContextFactory
    {
        public static PlayerContext Create(MobileInputsManager inputs, PlayerMovement playerMovement, PlayerGraphicsController graphics)
        {
            return new PlayerContext(inputs, playerMovement, graphics);
        }
    }
}

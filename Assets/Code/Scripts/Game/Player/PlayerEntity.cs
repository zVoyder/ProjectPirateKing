namespace ProjectPK.Player
{
    using ProjectPK.Player.Interfaces;
    using ProjectPK.Player.Manager;
    using VUDK.Features.Main.EntitySystem;

    public class PlayerEntity : EntityBase, IPlayerComponent
    {
        public void Init(PlayerManager player)
        {
        }

        protected override void OnDeath()
        {
        }
    }
}

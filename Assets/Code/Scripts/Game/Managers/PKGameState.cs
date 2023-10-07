namespace ProjectPK.Managers
{
    using UnityEngine;
    using VUDK.Features.Main.InputSysten.MobileInputs;
    using VUDK.Generic.Managers.GameManager;

    public class PKGameState : GameState
    {
        [field: SerializeField, Header("Mobile Inputs")]
        public MobileInputsManager MobileInputsManager { get; private set; }
    }
}

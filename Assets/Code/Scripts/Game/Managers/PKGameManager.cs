namespace ProjectPK.Managers
{
    using UnityEngine;
    using VUDK.Features.Main.InputSysten.MobileInputs;
    using VUDK.Generic.Managers.GameManagers;

    public class PKGameManager : GameManager
    {
        [field: SerializeField, Header("Mobile Inputs")]
        public MobileInputsManager MobileInputsManager { get; private set; }
    }
}

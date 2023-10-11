namespace ProjectPK.Player
{
    using UnityEngine;
    using VUDK.Features.Main.Inputs.MobileInputs.Keys;
    using ProjectPK.Player.Interfaces;
    using ProjectPK.Player.Manager;

    public class PlayerCombat : MonoBehaviour, IPlayerComponent
    {
        [SerializeField, Header("Attack Settings")]
        private float _attackDamage;

        private PlayerManager _playerManager;

        public void Init(PlayerManager player)
        {
            _playerManager = player;
        }

        private void OnEnable()
        {
            _playerManager.GameManager.MobileInputsManager.MobileInputsActions[MobileInputActionKeys.AButton].OnInputPerformed += Attack;
        }

        private void OnDisable()
        {
            _playerManager.GameManager.MobileInputsManager.MobileInputsActions[MobileInputActionKeys.AButton].OnInputPerformed -= Attack;
        }

        private void Attack()
        {
            _playerManager.Graphics.AnimateAttack();
        }
    }
}

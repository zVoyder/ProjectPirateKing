﻿namespace ProjectPK.Player.Manager
{
    using UnityEngine;
    using ProjectPK.Managers;
    using ProjectPK.Patterns.Factories;
    using ProjectPK.Player.Manager.Contexts;
    using ProjectPK.Player.Manager.States;
    using VUDK.Generic.Managers.Main;
    using VUDK.Generic.Managers.Main.Interfaces;
    using VUDK.Patterns.StateMachine;

    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCombat))]
    public class PlayerManager : StateMachine, ICastGameManager<PKGameManager>
    {
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public PlayerCombat Combat { get; private set; }

        public PKGameManager GameManager => MainManager.Ins.GameManager as PKGameManager;

        private void Awake()
        {
            TryGetComponent(out PlayerMovement movement);
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerCombat combat);

            Movement = movement;
            Graphics = graphics;
            Combat = combat;

            Movement.Init(this); // The order is important 'cause the Graphics component uses the Movement component.
            Graphics.Init(this);
            Combat.Init(this);

            Init();
        }

        public override void Init()
        {
            PlayerContext context = ContextFactory.Create(GameManager.MobileInputsManager, Movement, Graphics);

            PlayerGroundState groundState = PlayerStatesFactory.Create(PlayerStateKey.Ground, this, context) as PlayerGroundState;
            PlayerJumpState jumpState = PlayerStatesFactory.Create(PlayerStateKey.Jump, this, context) as PlayerJumpState;
            PlayerAirState airState = PlayerStatesFactory.Create(PlayerStateKey.Air, this, context) as PlayerAirState;

            AddState(PlayerStateKey.Ground, groundState);
            AddState(PlayerStateKey.Jump, jumpState);
            AddState(PlayerStateKey.Air, airState);

            ChangeState(PlayerStateKey.Ground);
        }
    }
}
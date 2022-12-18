using UnityEngine;
using Player;

namespace State
{
    public class GameState : AState
    {
        private GameObject MainGameUI;
        private Bullet.BulletView bulletView;

        public GameState(StateMachine owner, Menus menus, Bullet.BulletView bulletView) : base(owner)
        {
            MainGameUI = menus.MainGameUI;
            this.bulletView = bulletView;
        }

        public override void Enter()
        {
            Time.timeScale = 1;
            Core.Game.onGameStart -= owner.ChangeState;
            Cannon.OnShoot += bulletView.View;
            Cannon.OnReload += bulletView.Realod;
            MainGameUI.SetActive(true);
        }

        public override void Exit()
        {
            Cannon.OnShoot -= bulletView.View;
            Cannon.OnReload -= bulletView.Realod;
        }

        public override void Update()
        {
            
        }
    }
}
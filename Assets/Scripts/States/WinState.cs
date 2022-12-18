using UnityEngine;
using TMPro;

namespace State
{
    public class WinState : AState
    {
        private GameObject winMenu;
        private GameObject MainGameUI;

        public WinState(StateMachine owner, Menus menus) : base(owner)
        {
            winMenu = menus.WinMenu;
            MainGameUI = menus.MainGameUI;
        }

        public override void Enter()
        {
            Time.timeScale = 0;
            winMenu.SetActive(true);
            MainGameUI.SetActive(false);
            winMenu.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Score: {PlayerPrefs.GetInt("CurrentScore")}";
            Core.Game.onGameEnd -= owner.ChangeState;
        }

        public override void Exit()
        {
            Time.timeScale = 1;
            winMenu.SetActive(false);
        }

        public override void Update()
        {
            
        }
    }
}
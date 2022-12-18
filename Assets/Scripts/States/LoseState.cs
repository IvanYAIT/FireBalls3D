using TMPro;
using UnityEngine;

namespace State
{
    public class LoseState : AState
    {
        private GameObject loseMenu;
        private GameObject MainGameUI;

        public LoseState(StateMachine owner, Menus menus) : base(owner)
        {
            loseMenu = menus.LoseMenu;
            MainGameUI = menus.MainGameUI;
        }

        public override void Enter()
        {
            Time.timeScale = 0;
            loseMenu.SetActive(true);
            MainGameUI.SetActive(false);
            Core.Game.onGameEnd -= owner.ChangeState;
        }

        public override void Exit()
        {
            Time.timeScale = 1;
            loseMenu.SetActive(false);
        }

        public override void Update()
        {
            loseMenu.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Score: {PlayerPrefs.GetInt("CurrentScore")}";
        }
    }
}
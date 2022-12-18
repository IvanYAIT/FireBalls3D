using State;
using System;
using UnityEngine;

namespace Core
{
    public class Game
    {
        public static Action<Type> onGameStart;
        public static Action<Type> onGameEnd;

        private int level = 1;

        public Game()
        {
            Level.LevelEndChecker.onLevelEnd += EndGame;
            level = PlayerPrefs.GetInt("Level");
        }

        public void StartGame()
        {
            onGameStart?.Invoke(typeof(GameState));
        }

        public void EndGame(bool win)
        {
            if (win)
            {
                level++;
                PlayerPrefs.SetInt("Level", level);
                onGameEnd?.Invoke(typeof(WinState));
            }
            else
            {
                onGameEnd?.Invoke(typeof(LoseState));
                PlayerPrefs.SetInt("Level", 1);
                PlayerPrefs.SetInt("AmountOfFloors", 0);
                PlayerPrefs.SetInt("Score", 0);
            }
            Level.LevelEndChecker.onLevelEnd -= EndGame;
        }

        public void LoseCheck(int score)
        {
            if (score < 0)
                EndGame(false);
        }
    }
}
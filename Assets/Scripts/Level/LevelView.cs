using TMPro;
using UnityEngine;

namespace Level
{
    public class LevelView
    {
        private TextMeshProUGUI levelText;
        private int level;

        public LevelView(TextMeshProUGUI levelText)
        {
            this.levelText = levelText;
            level = PlayerPrefs.GetInt("Level");
        }

        public void View() =>
            levelText.text = $"Level {level}";
    }
}
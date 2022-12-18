using System;
using UnityEngine;

namespace Level
{
    public class LevelEndChecker
    {
        private Transform tower;

        public LevelEndChecker(Transform tower)
        {
            this.tower = tower;
        }

        public static Action<bool> onLevelEnd;

        public void Check()
        {
            if (tower.childCount == 0)
                onLevelEnd?.Invoke(true);
        }
    }
}


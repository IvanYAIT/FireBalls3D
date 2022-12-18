using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "SO/NewLevelData")]
    public class LevelData : ScriptableObject
    {
        public List<Tower.SceneObjectData> towerFloors;
        public int amountOfFloors;
        public List<Tower.SceneObjectData> obstacles;
        public int addingFloorsPerLvl;
    }
}


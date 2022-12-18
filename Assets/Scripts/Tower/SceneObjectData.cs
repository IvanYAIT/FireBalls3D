using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "SceneObjectData", menuName = "SO/NewSceneObjectData")]
    public class SceneObjectData : ScriptableObject
    {
        public GameObject floorPrefab;
        public int cost;
    }
}

using UnityEngine;

namespace Obstacle
{
    public class ObstacleSpinner : MonoBehaviour
    {
        [SerializeField] private Tower.SceneObjectData obstacle;
        public Tower.SceneObjectData Obstacle => obstacle;

        void Update()
        {
            transform.Rotate(new Vector3(0, 1, 0), 0.3f);
        }
    }
}
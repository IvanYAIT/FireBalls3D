using System;
using UnityEngine;

namespace Obstacle
{
    public class Obstacle : MonoBehaviour
    {
        private int Cost { get; set; }
        public static Action<int> OnObstacleHit;

        private void Start()
        {
            Cost = -1*transform.parent.GetComponent<ObstacleSpinner>().Obstacle.cost;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("bullet"))
            {
                Destroy(gameObject);
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + Cost);
            }
                
        }

        private void OnDestroy()
        {
            OnObstacleHit?.Invoke(Cost);
        }
    }
}
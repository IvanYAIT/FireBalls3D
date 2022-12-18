using System;
using UnityEngine;

namespace Tower
{
    public class TowerFloor : MonoBehaviour
    {
        public int Cost { get; set; }
        public static Action<int> OnTowerFloorDestroy;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("bullet"))
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + Cost);
                Destroy(gameObject);
            }
                
        }

        private void OnDestroy()
        {
            OnTowerFloorDestroy?.Invoke(Cost);
        }
    }
}
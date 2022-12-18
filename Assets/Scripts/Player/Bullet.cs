using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;

        void Update()
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("TowerFloor") || collision.gameObject.CompareTag("Obstacle"))
                Destroy(gameObject);
        }
    }
}
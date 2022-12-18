using System;
using UnityEngine;

namespace Player
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] Transform firePoint;

        public static Action OnShoot;
        public static Action OnReload;

        private GameObject bullet;
        private int amountOfBullets;

        private int currentAmountOfBullets;
        private bool isReload;

        public void Construct(GameObject bullet, int amountOfBullets)
        {
            this.bullet = bullet;
            this.amountOfBullets = amountOfBullets;
            Bullet.BulletController.OnReloadEnd += EndReload;
        }

        private void Start()
        {
            currentAmountOfBullets = amountOfBullets;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isReload)
            {
                Fire();
            }
            if (currentAmountOfBullets <= 0)
            {
                isReload = true;
            }
            if (isReload)
            {
                Reload();
            }
        }

        public void Fire()
        {
            if (currentAmountOfBullets > 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                currentAmountOfBullets--;
                OnShoot?.Invoke();
            }
            else
            {
                isReload = true;
            }
        }

        public void Reload()
        {
            OnReload?.Invoke();
        }

        public void EndReload()
        {
            isReload = false;
            currentAmountOfBullets = amountOfBullets;
        }
    }
}
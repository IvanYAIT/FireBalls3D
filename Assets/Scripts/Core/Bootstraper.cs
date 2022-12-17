using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private Cannon cannon;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int amountOfBullets;
        [SerializeField] private Image bulletImage;

        private BulletView bulletView;
        private Game game;

        void Start()
        {
            cannon.Construct(bulletPrefab, amountOfBullets);
            bulletView = new BulletView(bulletImage, amountOfBullets);
            //game.StartGame();
        }

        void Update()
        {

        }
    }
}
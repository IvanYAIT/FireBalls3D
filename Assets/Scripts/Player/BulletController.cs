using System;
using UnityEngine.UI;

namespace Bullet
{
    public class BulletController
    {
        public static Action OnReloadEnd;

        public void View(Image bulletImage, int bulletAmount, int costPerShoot)
        {
            bulletImage.GetComponent<Image>().fillAmount -= (float)costPerShoot / bulletAmount;
        }

        public void Realod(Image bulletImage, int cooldown)
        {
            bulletImage.GetComponent<Image>().fillAmount += (float)1 / (cooldown*100);
            if (bulletImage.GetComponent<Image>().fillAmount == 1)
                OnReloadEnd?.Invoke();
        }
    }
}
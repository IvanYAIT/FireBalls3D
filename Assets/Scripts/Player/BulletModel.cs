using UnityEngine;
using UnityEngine.UI;

namespace Bullet
{
    public class BulletModel : MonoBehaviour
    {
        [SerializeField] private Image bulletImage;
        [SerializeField] private int bulletAmount;
        [SerializeField] private int costPerShoot;
        [SerializeField] private int cooldown;

        public Image BulletImage => bulletImage;
        public int CostPerShoot => costPerShoot;
        public int BulletAmount => bulletAmount;
        public int Cooldown => cooldown;
    }
}
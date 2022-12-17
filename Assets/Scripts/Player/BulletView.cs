using UnityEngine.UI;

public class BulletView
{
    private Image bulletImage;
    private int bulletAmount;

    public BulletView(Image bulletImage, int bulletAmount)
    {
        this.bulletImage = bulletImage;
        this.bulletAmount = bulletAmount;
        Cannon.OnShoot += View;
        Cannon.OnReload += Realod;
    }

    public void View()
    {
        bulletImage.GetComponent<Image>().fillAmount -= (float)1/bulletAmount;
    }

    public void Realod()
    {
        bulletImage.GetComponent<Image>().fillAmount = 1;
    }
}

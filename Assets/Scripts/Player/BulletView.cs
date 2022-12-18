namespace Bullet
{
    public class BulletView
    {
        private BulletModel model;
        private BulletController controller;

        public BulletView(BulletModel model, BulletController controller)
        {
            this.model = model;
            this.controller = controller;
        }

        public void View()
        {
            controller.View(model.BulletImage, model.BulletAmount, model.CostPerShoot);
        }

        public void Realod()
        {
            controller.Realod(model.BulletImage, model.Cooldown);
        }
    }
}
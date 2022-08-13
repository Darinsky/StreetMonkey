using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;





namespace StreetMonkey.Displays.Projectiles
{

    public class Bullet : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }

    }


}
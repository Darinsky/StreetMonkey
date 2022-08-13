using MelonLoader;
using Harmony;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using System;
using System.Text.RegularExpressions;
using System.IO;
using Assets.Main.Scenes;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Simulation.Track;
using static Assets.Scripts.Models.Towers.TargetType;
using Assets.Scripts.Simulation;
using Assets.Scripts.Models.Towers.Pets;
using Assets.Scripts.Unity.Bridge;
using System.Windows;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Display;
using Assets.Scripts.Unity.Display;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper;
using Assets.Scripts.Models.Towers.Upgrades;
using HarmonyLib;
using BTD_Mod_Helper.Api;
using Assets.Scripts.Models.Towers.Filters;

















namespace StreetMonkey
{

 
   public class StreetMonkeyDis000 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 0, 0, 2);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
    }
    public class StreetMonkeyDis300 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 2, 0, 3);

        public override void ModifyDisplayNode(UnityDisplayNode node) {
            this.SetMeshTexture(node, "gundisplayxxx");
             node.RemoveBone("supermonkeyRig:Wrench");
            }
       
    }
    public class StreetMonkeyDis200 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 2, 0, 2);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
    }
    public class StreetMonkeyDis001 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 0, 0, 1);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
        
    }
    public class StreetMonkeyDis002 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 0, 0, 3);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
        
        
    }
   public class pleaseforthefuckingloveofgodijustwantthewrenchgone : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 2);

        
        public override void ModifyDisplayNode(UnityDisplayNode node) => node.RemoveBone("EngineerMonkeyRig:Wrench");
        
    }
    public class StreetMonkeyDis500 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.DartlingGunner, 3, 0, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
        
    }
     public class StreetMonkeyDis040 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 0, 4, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
        
    }
    public class StreetMonkeyDis005 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.SniperMonkey, 0, 0, 4);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
        
    }
    public class StreetMonkeyDis050 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 0, 5, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
        
    }
   
    public class StreetMonkeyDis555 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.EngineerMonkey, 0, 0, 5);

        public override void ModifyDisplayNode(UnityDisplayNode node) => this.SetMeshTexture(node, "gundisplayxxx");
        
    }

    public class StreetMonkey : ModTower
    {
       

        public override string TowerSet => MILITARY;
        
        public override string BaseTower => TowerType.EngineerMonkey;
        public override string Icon => base.Icon;
        

        public override int Cost => 530;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Shoots Bloons with his Trusty Gun";
        
        
    

       //public override ParagonMode ParagonMode => ParagonMode.Base000;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range += 5;
            

           
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 5;

            var projectile = attackModel.weapons[0].projectile;
            //projectile.ApplyDisplay<Bullet>();
           
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                    1, 2, false, false));
                     
              projectile.GetDamageModel().damage +=1;
            projectile.GetBehavior<TravelStraitModel>().Speed = 550f ;
            towerModel.ApplyDisplay<StreetMonkeyDis000>();
            
                
                   

                
             foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.Rate = 1.75f;
                 
               
                
            
            }
            
        }
        public override IEnumerable<int[]> TowerTiers()
        {
            if (MelonHandler.Mods.OfType<BloonsTD6Mod>().Any(m => m.GetModName() == "UltimateCrosspathing"))
            {
                for (var top = 0; top <= TopPathUpgrades; top++)
                {
                    for (var mid = 0; mid <= MiddlePathUpgrades; mid++)
                    {
                        for (var bot = 0; bot <= BottomPathUpgrades; bot++)
                        {
                            yield return new[] { top, mid, bot };
                        }
                    }
                }
            } else
            {
                foreach (var towerTier in base.TowerTiers())
                {
                    yield return towerTier;
                }
            }
        }  
       
        
    }
}





//TOP PATH UPGARAES
namespace StreetMonkey.Upgrades.TopPath
{
    public class FasterFiring : ModUpgrade<StreetMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 200;

        public override string DisplayName => "Faster Firing";
        public override string Description => "Improved Gun Tech allows the gun to be fired faster";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.Rate *= .85f;
               
            }
            
                var attackModel = towerModel.GetAttackModel();
                
                            
        }

    }

}
namespace StreetMonkey.Upgrades.TopPath
{
    public class DualWeilding : ModUpgrade<StreetMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 450;

        public override string DisplayName => "Dual Weilding";
        public override string Description => "The Monkey finally realizes he can use his other hand for more fire power";

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.Rate *= .75f;
                
                
            }
            
                var attackModel = towerModel.GetAttackModel();
                towerModel.ApplyDisplay<StreetMonkeyDis002>();
                            
        }

    }

}
 namespace StreetMonkey.Upgrades.TopPath
{
    public class SubMachine : ModUpgrade<StreetMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1650;

        public override string DisplayName => "Submachine Gun";
        public override string Description => "Replaces the two handguns with two SMG, giving faster shooting speed";
      

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.Rate *= .14f;
              
            }
            
                var attackModel = towerModel.GetAttackModel();
                towerModel.ApplyDisplay<StreetMonkeyDis300>();
                            
        }

    }

}
 namespace StreetMonkey.Upgrades.TopPath
{
    public class FullAutoRifle : ModUpgrade<StreetMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 7750;

        public override string DisplayName => "Full Auto rifle";
        public override string Description => "Dual Weilds 2 Full Auto Rifles for crazy results";

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                
                weaponModel.Rate *= .2f;
            }
            
                var attackModel = towerModel.GetAttackModel();
                
            var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=0;
        }

    }

}
namespace StreetMonkey.Upgrades.TopPath
{
    public class Minigun : ModUpgrade<StreetMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 37500;

        public override string DisplayName => "Minigun";
        public override string Description => "I am Heavy Weapons Guy, and this, is my weapon";
        
       

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.Rate *= .7f;
                weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                weaponModel.projectile.pierce +=4;
            }
               towerModel.ApplyDisplay<StreetMonkeyDis500>();
            
                var attackModel = towerModel.GetAttackModel();
                
            var projectile = attackModel.weapons[0].projectile;
                towerModel.GetWeapon().emission = new RandomArcEmissionModel("RandomArcEmissionModel_",2 ,0 , 15, 50, 5, null);
            
        }

    }

}



// MIDDLE PATH
namespace StreetMonkey.Upgrades.MiddlePath
{
    public class Radio: ModUpgrade<StreetMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 225;

        public override string DisplayName => "Radio";
        public override string Description => "Radio Conferencing help the Monkey detect bloons from further away";

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
               
            }
            
                var attackModel = towerModel.GetAttackModel();
                towerModel.range += 25;
                attackModel.range += 25;
               
      
        }

    }

}

    
namespace StreetMonkey.Upgrades.MiddlePath
{ 
public class glasses : ModUpgrade<StreetMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 2250;

        public override string DisplayName => "Infrared Goggles";
        public override string Description => "Infrared Goggles allows nearby monkeys, including himself, to see camo bloons";
        public override int Priority => -1;
        public override void ApplyUpgrade(TowerModel towerModel)
          { 
            
              towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
               foreach (var weaponModel in towerModel.GetWeapons())
            {
               
            }
            
                var attackModel = towerModel.GetAttackModel();
                towerModel.range += 5;
                attackModel.range += 5;
            var visibilitySupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 2, 0)
                    .GetBehavior<VisibilitySupportModel>().Duplicate();
            towerModel.AddBehavior(visibilitySupportModel);
                            
        }

    }

    }

namespace StreetMonkey.Upgrades.MiddlePath
{ 
public class Feartactics : ModUpgrade<StreetMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 3200;

        public override string DisplayName => "Fear Tactics";
        public override string Description => "Fear Tactics scare the bloons with a ring of \"death\" ";
       
        public override void ApplyUpgrade(TowerModel towerModel)
          { 
            
              
              
            
                var attackModel = towerModel.GetAttackModel();
                towerModel.range += 0;
                attackModel.range += 0;
            var slowBloonsZoneModel = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 3, 0)
                    .GetBehavior<SlowBloonsZoneModel>().Duplicate();
            slowBloonsZoneModel.speedChange = 7f;
            towerModel.AddBehavior(slowBloonsZoneModel); 
             TowerModel tower = Game.instance.model.GetTower("TackShooter", 5, 2, 0);
                var fireRing = tower.GetBehaviors<DisplayModel>()[1]; 
            fireRing.scale = 10f;
            towerModel.AddBehavior(fireRing);
            towerModel.ApplyDisplay<StreetMonkeyDis200>();

                            
        }

    }

    }
namespace StreetMonkey.Upgrades.MiddlePath
{ 
public class Reinforcements : ModUpgrade<StreetMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 8950;

        public override string DisplayName => "Reinforcements";
        public override string Description => "Calls in reinforcements for money every round and supplies for nearby monkeys";
       
        public override void ApplyUpgrade(TowerModel towerModel)
          { 
            
              
               foreach (var weaponModel in towerModel.GetWeapons())
            {
               
            }
               var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=2;
            towerModel.ApplyDisplay<StreetMonkeyDis040>();
              
            if (Tier == 4)
            {
                var perRoundCashBonusTowerModel = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 0, 5)
                    .GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
            perRoundCashBonusTowerModel.cashPerRound = 980;
            towerModel.AddBehavior(perRoundCashBonusTowerModel);
                var discountZoneModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 2)
                .GetBehavior<DiscountZoneModel>().Duplicate();
            discountZoneModel.affectSelf = false;
            discountZoneModel.discountMultiplier = 0.05f;
            discountZoneModel.tierCap = 2;
            towerModel.AddBehavior(discountZoneModel);
                var rateSupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 2, 0, 0)
                    .GetBehavior<RateSupportModel>().Duplicate();
                 rateSupportModel.multiplier = .9f;
                towerModel.AddBehavior(rateSupportModel);
            
            }
            
            
            
            
            
            
            
              
                            
        }

    }

    }
namespace StreetMonkey.Upgrades.MiddlePath
{ 
public class StreetLeader : ModUpgrade<StreetMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 75000;

        public override string DisplayName => "Street Leader";
        public override string Description => "The Master of the Streets";
        
       
        public override void ApplyUpgrade(TowerModel towerModel)
          { 
           var attackModel = towerModel.GetAttackModel();
              
               foreach (var weaponModel in towerModel.GetWeapons())
            {
               
                weaponModel.Rate *= .75f;
                weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                weaponModel.projectile.pierce +=6;
            }
                
            var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=20;
                
                towerModel.range += 3;
                attackModel.range += 3;
             if (Tier == 5)
            {
                var perRoundCashBonusTowerModel = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 0, 5)
                    .GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
            perRoundCashBonusTowerModel.cashPerRound = 2550;
            towerModel.AddBehavior(perRoundCashBonusTowerModel);
               
            
            }
                var monkeyCityModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 4)
                    .GetBehavior<MonkeyCityModel>().Duplicate();
                monkeyCityModel.towerId = "StreetMonkey";
                monkeyCityModel.multiplier = 1;
                monkeyCityModel.roundsTillMultiplier = 1;
                towerModel.AddBehavior(monkeyCityModel);
           
            
            var discountZoneModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 2)
                .GetBehavior<DiscountZoneModel>().Duplicate();
            discountZoneModel.affectSelf = true;
            discountZoneModel.discountMultiplier = 0.10f;
            discountZoneModel.tierCap = 3;
            towerModel.AddBehavior(discountZoneModel);

             var discountZoneModel1 = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 2)
                .GetBehavior<DiscountZoneModel>().Duplicate();
            discountZoneModel1.affectSelf = true;
            discountZoneModel1.discountMultiplier = 0.075f;
            discountZoneModel1.tierCap = 4;
            towerModel.AddBehavior(discountZoneModel1);

            var monkeyCityIncomeSupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 4)
                    .GetBehavior<MonkeyCityIncomeSupportModel>().Duplicate();
                monkeyCityIncomeSupportModel.incomeModifier = 1.15f;
                towerModel.AddBehavior(monkeyCityIncomeSupportModel);


            var addBehaviorToTowerSupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 4)
                    .GetBehavior<AddBehaviorToTowerSupportModel>().Duplicate();
                 
                towerModel.AddBehavior(addBehaviorToTowerSupportModel);
           var rateSupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 2, 0, 0)
                    .GetBehavior<RateSupportModel>().Duplicate();
                 rateSupportModel.multiplier = .8f;
                towerModel.AddBehavior(rateSupportModel);
            towerModel.ApplyDisplay<StreetMonkeyDis040>();
                
        }

    }

    }

// BOTTOM PATH
namespace StreetMonkey.Upgrades.MiddlePath
{
    public class NineMil : ModUpgrade<StreetMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 275;

        public override string DisplayName => ".9 Millimeter";
        public override string Description => "Improves Bullets allow more layer piercing";
        public override string Icon => base.Icon;
        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
               
            }
            
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=1;
               
      
        }

    }

}
namespace StreetMonkey.Upgrades.MiddlePath
{
    public class FourtySW : ModUpgrade<StreetMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 650;

        public override string DisplayName => ".40 S&W rounds";
        public override string Description => "S&W rounds allows for even more damage";

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
               weaponModel.Rate *= .95f;
            }
            
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
           
                projectile.GetDamageModel().damage +=1;

            
               
      
        }

    }

}
namespace StreetMonkey.Upgrades.MiddlePath
{
    public class Magnum : ModUpgrade<StreetMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 1150;

        public override string DisplayName => ".357 Magnum rounds";
        public override string Description => ".357 Magnum rounds allows the poppage of lead, and bonus damage to all";

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
               weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                weaponModel.Rate *= .9f;
            }
               towerModel.ApplyDisplay<StreetMonkeyDis001>();
            
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
            
            projectile.GetDamageModel().damage +=1;
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                    1, 10, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                    1, 5, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified",
                    1, 5, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Boss", "Boss",
                    1, 250, false, false));
               
      
        }

    }

}
namespace StreetMonkey.Upgrades.MiddlePath
{
    public class Winchester : ModUpgrade<StreetMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 4500;

        public override string DisplayName => ".308 Winchester Rounds";
        public override string Description => "Does EVEN more damage per shot, and EVEN more damage to MOABs";

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                weaponModel.Rate *= .85f;
                weaponModel.projectile.pierce +=25;
                
            }
            
            
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                    1, 10, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                    1, 5, false, false));
            projectile.GetDamageModel().damage +=5;

            
               
      
        }

    }

}
namespace StreetMonkey.Upgrades.MiddlePath
{
    public class BMG : ModUpgrade<StreetMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 45000;

        public override string DisplayName => ".50 BMG Rounds";
        public override string Description => "This is a STRONG bullet";

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                weaponModel.Rate *= 0.70f;
                weaponModel.projectile.pierce +=350;
                
            }
            towerModel.ApplyDisplay<StreetMonkeyDis005>();
            
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
            
            projectile.GetDamageModel().damage += 250;
              projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                    1, 150, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                    1, 120, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified",
                    1, 75, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Boss", "Boss",
                    1, 1250, false, false));
             
           
            
           
        }

    }

}

namespace StreetMonkey.Upgrades
{
    public class StreetParagon : ModParagonUpgrade<StreetMonkey>
    {  
              
        public override int Cost => 750000;
        public override string Description => "The Legend of the Streets";
        public override string DisplayName => "Street Legend";

        
        
        public override void ApplyUpgrade(TowerModel towerModel)
        {
          
            var attackModel = towerModel.GetAttackModel();

               var projectile = attackModel.weapons[0].projectile;
            attackModel.attackThroughWalls = true;
            projectile.GetDamageModel().damage = 1;
            var perRoundCashBonusTowerModel = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 0, 5)
                    .GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
            perRoundCashBonusTowerModel.cashPerRound = 32250;
            towerModel.AddBehavior(perRoundCashBonusTowerModel);
           towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                weaponModel.Rate *= .015f;
                weaponModel.projectile.pierce = 999;
                towerModel.GetWeapon().emission = new RandomArcEmissionModel("RandomArcEmissionModel_",15 ,0 , 15, 50, 5, null);
               var visibilitySupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 2, 0)
                    .GetBehavior<VisibilitySupportModel>().Duplicate();
            towerModel.AddBehavior(visibilitySupportModel);
               weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                
                
            }
               // Support shit from x5x

               var monkeyCityModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 4)
                    .GetBehavior<MonkeyCityModel>().Duplicate();
                monkeyCityModel.towerId = "StreetMonkey";
                monkeyCityModel.multiplier = 1;
                monkeyCityModel.roundsTillMultiplier = 1;
                towerModel.AddBehavior(monkeyCityModel);
           
            
            var discountZoneModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 2)
                .GetBehavior<DiscountZoneModel>().Duplicate();
            discountZoneModel.affectSelf = true;
            discountZoneModel.discountMultiplier = 0.10f;
            discountZoneModel.tierCap = 3;
            towerModel.AddBehavior(discountZoneModel);

             var discountZoneModel1 = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 2)
                .GetBehavior<DiscountZoneModel>().Duplicate();
            discountZoneModel1.affectSelf = true;
            discountZoneModel1.discountMultiplier = 0.075f;
            discountZoneModel1.tierCap = 4;
            towerModel.AddBehavior(discountZoneModel1);

            var monkeyCityIncomeSupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 4)
                    .GetBehavior<MonkeyCityIncomeSupportModel>().Duplicate();
                monkeyCityIncomeSupportModel.incomeModifier = 1.15f;
                towerModel.AddBehavior(monkeyCityIncomeSupportModel);


            var addBehaviorToTowerSupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 4)
                    .GetBehavior<AddBehaviorToTowerSupportModel>().Duplicate();
                 
                towerModel.AddBehavior(addBehaviorToTowerSupportModel);
           var rateSupportModel = Game.instance.model.GetTower(TowerType.MonkeyVillage, 2, 0, 0)
                    .GetBehavior<RateSupportModel>().Duplicate();
                 rateSupportModel.multiplier = .8f;
                towerModel.AddBehavior(rateSupportModel);


            towerModel.range += 45;
                attackModel.range += 45;


             var slowBloonsZoneModel = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 3, 0)
                    .GetBehavior<SlowBloonsZoneModel>().Duplicate();
            slowBloonsZoneModel.speedChange = 7f;
            towerModel.AddBehavior(slowBloonsZoneModel); 
             TowerModel tower = Game.instance.model.GetTower("TackShooter", 5, 2, 0);
                var fireRing = tower.GetBehaviors<DisplayModel>()[1]; 
            fireRing.scale = 10f;
            towerModel.AddBehavior(fireRing);
            towerModel.ApplyDisplay<StreetMonkeyDis200>();
        }
         
    }
  
}



    




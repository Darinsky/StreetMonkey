using BTD_Mod_Helper;
using StreetMonkey;
using MelonLoader;

[assembly: MelonModInfo(typeof(StreetMonkey.StreetMonkeyMain), "The Street Monkey", "1.2.0", "Darinsky")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace StreetMonkey
{
    public class StreetMonkeyMain : BloonsTD6Mod
    {
        // No Harmony Patches or hooks required for this whole tower!
    }
}
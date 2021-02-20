using HarmonyLib;
using System;

namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(WearNTear), "HaveRoof")]
    public class RemoveWearNTear : BasePatch
    {
        
        private static void Postfix(ref Boolean __result)
        {
            if (Conf.Building.IsEnabled && Conf.Building.NoWeatherDamage)
            {
                __result = true;
            }
        }
    }
}

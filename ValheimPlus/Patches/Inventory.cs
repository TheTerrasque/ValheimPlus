using HarmonyLib;
using System;

namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(Inventory), "IsTeleportable")]
    public class noItemTeleportPrevention: BasePatch
    {
        private static void Postfix(ref Boolean __result)
        {
            if (Conf.Items.IsEnabled)
            {
                if (Conf.Items.NoTeleportPrevention)
                    __result = true;
            }
        }
    }
}

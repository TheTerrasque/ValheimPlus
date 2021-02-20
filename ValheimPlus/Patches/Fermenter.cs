using HarmonyLib;

namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(Fermenter), "Awake")]
    public class ApplyFermenterChanges: BasePatch
    {
        private static bool Prefix(ref float ___m_fermentationDuration, ref Fermenter __instance)
        {
            if (Conf.Fermenter.IsEnabled)
            {
                float fermenterDuration = Conf.Fermenter.FermenterDuration;
                if (fermenterDuration > 0)
                {
                    ___m_fermentationDuration = fermenterDuration;
                }
            }
            return true;
        }

    }
    [HarmonyPatch(typeof(Fermenter), "GetItemConversion")]
    public class ApplyFermenterItemCountChanges: BasePatch
    {
        private static void Postfix(ref Fermenter.ItemConversion __result)
        {
            if (Conf.Fermenter.IsEnabled)
            {
                int fermenterItemCount = Conf.Fermenter.FermenterItemsProduced;
                if (fermenterItemCount > 0)
                {
                    __result.m_producedItems = fermenterItemCount;
                }
            }

        }

    }
}

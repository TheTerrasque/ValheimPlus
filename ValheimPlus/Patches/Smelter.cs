using HarmonyLib;


namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(Smelter), "Awake")]
    public class ApplyFurnaceChanges :BasePatch
    {
        private static void Prefix(ref Smelter __instance)
        {
            if (!__instance.m_addWoodSwitch)
            {
                // is kiln
                if (Conf.Kiln.IsEnabled)
                {
                    __instance.m_maxOre = Conf.Kiln.MaximumWood;
                    __instance.m_secPerProduct = Conf.Kiln.ProductionSpeed;
                }
            }
            else
            {
                // is furnace
                if (Conf.Furnace.IsEnabled)
                {
                    __instance.m_maxOre = Conf.Furnace.MaximumOre;
                    __instance.m_maxFuel = Conf.Furnace.MaximumCoal;
                    __instance.m_secPerProduct = Conf.Furnace.ProductionSpeed;
                    __instance.m_fuelPerProduct = Conf.Furnace.CoalUsedPerProduct;
                }
            }
        }
    }
}

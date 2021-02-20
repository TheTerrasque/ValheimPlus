using HarmonyLib;

namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(Beehive), "Awake")]
    public class ApplyBeehiveChanges: BasePatch
    {
        private static bool Prefix(ref float ___m_secPerUnit, ref int ___m_maxHoney)
        {
            if (Conf.Beehive.IsEnabled)
            {
                ___m_secPerUnit = Conf.Beehive.HoneyProductionSpeed;
                ___m_maxHoney = Conf.Beehive.MaximumHoneyPerBeehive;
            }
            return true;
        }

    }
}

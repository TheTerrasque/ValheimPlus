using HarmonyLib;
using System.Text;
using UnityEngine;

namespace ValheimPlus.Patches
{
    class Workbench
    {
        [HarmonyPatch(typeof(CraftingStation), "Start")]
        public class WorkbenchRangeIncrease : BasePatch
        {
            private static void Prefix(ref float ___m_rangeBuild, GameObject ___m_areaMarker)
            {
                if (Conf.Workbench.IsEnabled && Conf.Workbench.workbenchRange > 0)
                {
                    ___m_rangeBuild = Conf.Workbench.workbenchRange;
                }
            }
        }
    }
}

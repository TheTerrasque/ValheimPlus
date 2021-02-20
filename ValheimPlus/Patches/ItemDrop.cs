﻿using HarmonyLib;

namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(ItemDrop), "Awake")]
    public class ChangeTooltip : BasePatch
    {
        private static void Prefix(ref ItemDrop __instance)
        {

            if (Conf.Items.IsEnabled && Conf.Items.NoTeleportPrevention)
            {
                __instance.m_itemData.m_shared.m_teleportable = true;
            }

            /* Disabled for now. Need to hook the Item ToolTip function properly instead due to the way the game handles food durations.
            if (Settings.isEnabled("Food"))
            {
                float food_multiplier = Settings.getFloat("Food", "foodDuration");
                if (food_multiplier > 0)
                {
                    if (Convert.ToInt32(__instance.m_itemData.m_shared.m_itemType) == 2) // Item Type = Food
                        __instance.m_itemData.m_shared.m_foodBurnTime = __instance.m_itemData.m_shared.m_foodBurnTime + ((__instance.m_itemData.m_shared.m_foodBurnTime / 100) * food_multiplier);
                }
                if (food_multiplier < 0 && food_multiplier >= -100)
                {
                    if (Convert.ToInt32(__instance.m_itemData.m_shared.m_itemType) == 2) // Item Type = Food
                        __instance.m_itemData.m_shared.m_foodBurnTime = __instance.m_itemData.m_shared.m_foodBurnTime - ((__instance.m_itemData.m_shared.m_foodBurnTime / 100) * (food_multiplier * -1));
                }

            }*/


            if (Conf.Items.IsEnabled)
            {
                float itemWeigthReduction = Conf.Items.BaseItemWeightReduction;
                if (itemWeigthReduction > 0)
                {
                    __instance.m_itemData.m_shared.m_weight = __instance.m_itemData.m_shared.m_weight + ((__instance.m_itemData.m_shared.m_weight / 100) * itemWeigthReduction);
                }
                if (itemWeigthReduction < 0)
                {
                    __instance.m_itemData.m_shared.m_weight = __instance.m_itemData.m_shared.m_weight - ((__instance.m_itemData.m_shared.m_weight / 100) * (itemWeigthReduction * -1));
                }

                float itemStackMultiplier = Conf.Items.ItemStackMultiplier;
                if(__instance.m_itemData.m_shared.m_maxStackSize > 1)
                {
                    if (itemStackMultiplier >= 1)
                    {
                        __instance.m_itemData.m_shared.m_maxStackSize = __instance.m_itemData.m_shared.m_maxStackSize + (int)(((float)(__instance.m_itemData.m_shared.m_maxStackSize) / 100) * itemStackMultiplier);
                    }

                }
            }

        }
    }

}

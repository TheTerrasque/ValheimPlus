using HarmonyLib;

namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(Player), "Awake")]
    public class ModifyPlayerValues : BasePatch
    {
        private static void Postfix(Player __instance)
        {
            if (Conf.Stamina.IsEnabled)
            {
                __instance.m_dodgeStaminaUsage = Conf.Stamina.DodgeStaminaUsage; ;
                __instance.m_encumberedStaminaDrain = Conf.Stamina.EncumberedStaminaDrain;
                __instance.m_sneakStaminaDrain = Conf.Stamina.SneakStaminaDrain;
                __instance.m_runStaminaDrain = Conf.Stamina.RunStaminaDrain;
                __instance.m_staminaRegenDelay = Conf.Stamina.StaminaRegenDelay;
                __instance.m_staminaRegen = Conf.Stamina.StaminaRegen;
                __instance.m_swimStaminaDrainMinSkill = Conf.Stamina.SwimStaminaDrain;
                __instance.m_jumpStaminaUsage = Conf.Stamina.JumpStaminaUsage;
            }
            if (Conf.Player.IsEnabled)
            {
                __instance.m_autoPickupRange = Conf.Player.BaseAutoPickUpRange;
                __instance.m_baseCameraShake = Conf.Player.DisableCameraShake ? 0f : 4f;
            }
            if (Conf.Building.IsEnabled)
            {
                __instance.m_maxPlaceDistance = Conf.Building.MaximumPlacementDistance;
            }
        }


    }

    [HarmonyPatch(typeof(Attack), "GetStaminaUsage")]
    public class SelectiveWeaponStaminaDescrease : BasePatch
    {
        private static void Postfix(ref float __result, ItemDrop.ItemData ___m_weapon)
        {
            if (Conf.WeaponsStamina.IsEnabled)
            {
                string weaponType = ___m_weapon.m_shared.m_skillType.ToString();

                switch (weaponType)
                {
                    case "Swords":
                        __result = __result - __result * Conf.WeaponsStamina.swords / 100;
                        break;
                    case "Knives":
                        __result = __result - __result * Conf.WeaponsStamina.knives / 100;
                        break;
                    case "Clubs":
                        __result = __result - __result * Conf.WeaponsStamina.clubs / 100;
                        break;
                    case "Polearms":
                        __result = __result - __result * Conf.WeaponsStamina.polearms / 100;
                        break;
                    case "Spears":
                        __result = __result - __result * Conf.WeaponsStamina.spears / 100;
                        break;
                    case "Axes":
                        __result = __result - __result * Conf.WeaponsStamina.axes / 100;
                        break;
                    case "Bows":
                        __result = __result - __result * Conf.WeaponsStamina.bows / 100;
                        break;
                    case "Unarmed":
                        __result = __result - __result * Conf.WeaponsStamina.unarmed / 100;
                        break;
                    case "Pickaxes":
                        __result = __result - __result * Conf.WeaponsStamina.pickaxes / 100;
                        break;
                    default:
                        break;
                }
            }

        }
    }


}

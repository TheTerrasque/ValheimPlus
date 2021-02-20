using HarmonyLib;

namespace ValheimPlus.Patches
{
    [HarmonyPatch(typeof(Humanoid), "GetCurrentWeapon")]
    public class ModifyCurrentWeapon: BasePatch
    {
        private static ItemDrop.ItemData Postfix(ItemDrop.ItemData __weapon, ref Character __instance)
        {
            if (Conf.UnarmedScaling.IsEnabled)
            {
                if (__weapon != null)
                {
                    if (__weapon.m_shared.m_name == "Unarmed")
                    {
                        __weapon.m_shared.m_damages.m_blunt = __instance.GetSkillFactor(Skills.SkillType.Unarmed) * Conf.UnarmedScaling.baseDamage;
                    }
                }
            }

            return __weapon;
        }
    }
}

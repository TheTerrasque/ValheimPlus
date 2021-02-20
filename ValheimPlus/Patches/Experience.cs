using HarmonyLib;

namespace ValheimPlus
{
    class Experience: BasePatch
    {
        
        [HarmonyPatch(typeof(Skills), "RaiseSkill")]
        public static class AddExpGainedDisplay
        {

            /*
            private static void Prefix(Skills __instance, Skills.SkillType skillType, float factor = 1f)
            {
               

            }*/

            private static void Postfix(Skills __instance, Skills.SkillType skillType, float factor = 1f)
            {
                if (Conf.Player.IsEnabled && Conf.Player.ExperienceGainedNotifications)
                {
                    Skills.Skill skill = __instance.GetSkill(skillType);
                    float percent = skill.m_accumulator / (skill.GetNextLevelRequirement() / 100);
                    __instance.m_player.Message(MessageHud.MessageType.TopLeft, skill.m_info.m_skill + " [" + Helper.tFloat(skill.m_accumulator, 2) + "/" + Helper.tFloat(skill.GetNextLevelRequirement(), 2) + "] (" + Helper.tFloat(percent, 0) + "%)", 0, skill.m_info.m_icon);
                }
            }

        }
        
    }
}

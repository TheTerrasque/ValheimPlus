using System;
using ValheimPlus.Configurations;

namespace ValheimPlus
{
    public class BasePatch
    {
        public static Configuration Conf => Configuration.Current;
        public static Character getPlayerCharacter(Player __instance)
        {
            return (Character)__instance;
        }

    }
}

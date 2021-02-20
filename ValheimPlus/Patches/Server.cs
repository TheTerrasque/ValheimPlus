using HarmonyLib;
using Steamworks;
using System;

namespace ValheimPlus.Patches
{

    [HarmonyPatch(typeof(ZNet), "Awake")]
    public class ChangeGameServerVariables : BasePatch
    {
        private static void Postfix(ref ZNet __instance)
        {
            if (Conf.Server.IsEnabled)
            {
                int maxPlayers = Conf.Server.MaxPlayers;
                if (maxPlayers >= 1)
                {
                    // Set Server Instance Max Players
                    __instance.m_serverPlayerLimit = maxPlayers;
                }
            }

        }

    }
    [HarmonyPatch(typeof(SteamGameServer), "SetMaxPlayerCount")]
    public class ChangeSteamServerVariables : BasePatch
    {
        private static void Prefix(ref int cPlayersMax)
        {
            if (Conf.Server.IsEnabled)
            {
                int maxPlayers = Conf.Server.MaxPlayers;
                if (maxPlayers >= 1)
                {
                    cPlayersMax = maxPlayers;
                }
            }

        }

    }
    [HarmonyPatch(typeof(FejdStartup), "IsPublicPasswordValid")]
    public class ChangeServerPasswordBehavior : BasePatch
    {

        private static void Postfix(ref bool __result) // Set after awake function
        {
            if (Conf.Server.IsEnabled)
            {
                if (Conf.Server.DisableServerPassword)
                {
                    __result = true;
                }
            }
        }
    }
}

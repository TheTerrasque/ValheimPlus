using HarmonyLib;
using System;
using UnityEngine;

namespace ValheimPlus.Patches
{

    [HarmonyPatch(typeof(Player))]
    public class hookDodgeRoll : BasePatch
    {
        [HarmonyReversePatch]
        [HarmonyPatch(typeof(Player), "Dodge", new Type[] { typeof(Vector3) })]
        public static void Dodge(object instance, Vector3 dodgeDir) => throw new NotImplementedException();
    }
    [HarmonyPatch(typeof(Player), "Update")]
    public class ApplyDodgeHotkeys : BasePatch
    {
        private static void Postfix(ref Player __instance, ref Vector3 ___m_moveDir, ref Vector3 ___m_lookDir, ref GameObject ___m_placementGhost, Transform ___m_eye)
        {
            if (!Conf.Hotkeys.IsEnabled) return;

            KeyCode rollKeyForward = Conf.Hotkeys.RollForwards;
            KeyCode rollKeyBackwards = Conf.Hotkeys.RollBackwards;

            if (Input.GetKeyDown(rollKeyBackwards))
            {
                Vector3 dodgeDir = ___m_moveDir;
                if (dodgeDir.magnitude < 0.1f)
                {
                    dodgeDir = -___m_lookDir;
                    dodgeDir.y = 0f;
                    dodgeDir.Normalize();
                }
                hookDodgeRoll.Dodge(__instance, dodgeDir);
            }
            if (Input.GetKeyDown(rollKeyForward))
            {
                Vector3 dodgeDir = ___m_moveDir;
                if (dodgeDir.magnitude < 0.1f)
                {
                    dodgeDir = ___m_lookDir;
                    dodgeDir.y = 0f;
                    dodgeDir.Normalize();
                }
                hookDodgeRoll.Dodge(__instance, dodgeDir);
            }

        }

    }

}

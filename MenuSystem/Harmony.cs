using Harmony;

namespace MenuSystem
{
    [HarmonyPatch(typeof(GeneralMenu), "InitializeVirtual")]
    class GeneralMenu__InitializeVirtual
    {
        static void Postfix(GeneralMenu __instance)
        {
            Menu.MenuBlueprint = __instance.menuBlueprint_;

            __instance.TweakAction("CONFIGURE SPECTRUM PLUGINS", () => {
                Menu.ShowMenu("Spectrum Plugins", null, __instance, 0);
            });
        }
    }
}

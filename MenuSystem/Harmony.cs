using Harmony;
using System;

namespace MenuSystem
{
    [HarmonyPatch(typeof(GeneralMenu), "InitializeVirtual")]
    class GeneralMenu__InitializeVirtual
    {
        static void Postfix(GeneralMenu __instance)
        {
            Menu.menuBlueprint = __instance.menuBlueprint_;

            __instance.TweakAction("CONFIGURE SPECTRUM PLUGINS", () => {
                CreateMenu(__instance, 0);
            });
        }

        static void CreateMenu(GeneralMenu __instance, int page)
        {
            foreach (var component in __instance.PanelObject_.GetComponents<AutoMenu>())
                component.Destroy();

            AutoMenu menu = __instance.PanelObject_.AddComponent<AutoMenu>();

            menu.PageIndex = page;

            menu.MenuPanel = MenuPanel.Create(menu.PanelObject_, true, true, false, true, false, false);

            menu.MenuPanel.onPanelPop_ += () =>
            {
                if (!G.Sys.MenuPanelManager_.panelStack_.Contains(menu.MenuPanel))
                {
                    __instance.PanelObject_.SetActive(true);
                    if(menu.PageSwitching)
                        CreateMenu(__instance, menu.PageIndex);
                } 
            };

            menu.Title = "Configure Spectrum";
            for (int i = 0; i < 32; i++)
                menu.Entries.Add(new CheckBox(MenuItem.DisplayMode.Any, "item " + i, true, (v) => { }, "checkbox number " + i));


            __instance.PanelObject_.SetActive(false);

            G.Sys.MenuPanelManager_.Push(menu.MenuPanel);
        }
    }
}

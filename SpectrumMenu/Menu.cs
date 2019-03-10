using UnityEngine;

public static class Menu
{
    public static GameObject MenuBlueprint { get; set; }
    
    public static void ShowMenu(string title, MenuTree entries, SuperMenu parent, int page)
    {
        foreach (var component in parent.PanelObject_.GetComponents<SpectrumMenu>())
            component.Destroy();

        SpectrumMenu menu = parent.PanelObject_.AddComponent<SpectrumMenu>();

        menu.PageIndex = page;

        menu.MenuPanel = MenuPanel.Create(menu.PanelObject_, true, true, false, true, false, false);

        menu.MenuPanel.onPanelPop_ += () =>
        {
            if (!G.Sys.MenuPanelManager_.panelStack_.Contains(menu.MenuPanel))
            {
                parent.PanelObject_.SetActive(true);
                if (menu.PageSwitching)
                    ShowMenu(title, entries, parent, menu.PageIndex);
            }
        };

        menu.Title = title;
        menu.Entries = entries;
        
        parent.PanelObject_.SetActive(false);

        G.Sys.MenuPanelManager_.Push(menu.MenuPanel);
    }
}
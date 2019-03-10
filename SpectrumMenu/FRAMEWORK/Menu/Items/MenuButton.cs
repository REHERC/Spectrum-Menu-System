using System;

public class MenuButton : MenuItem
{
    private SpectrumMenu Menu { get; set; }
    public MenuTree MenuTree { get; set; }
    public string MenuTitle { get; set; }

    #region constructors
    public MenuButton(DisplayMode mode, string name, string title, MenuTree menu, string description = null) : base(mode, name, description)
    {
        this.MenuTree = menu;
    }
    #endregion

    public override void Tweak(SpectrumMenu menu)
    {
        menu.TweakAction(this.Name, () => {
            foreach (var component in menu.PanelObject_.GetComponents<SpectrumMenu>())
                if (component == this.Menu)
                    component.Destroy();

            //SpectrumMenu childmenu = menu.PanelObject_.AddComponent<SpectrumMenu>();
            //childmenu.MenuPanel = MenuPanel.Create(menu.PanelObject_, true, true, false, true, false, false);
            //childmenu.Title = this.MenuTitle;


            //childmenu.MenuPanel.onPanelPop_ += () =>
            //{
            //    if (menu.MenuPanel.IsTop_)
            //        menu.PanelObject_.SetActive(true);
            //};

            //menu.PanelObject_.SetActive(false);

            //G.Sys.menuPanelManager_.Push(childmenu.MenuPanel);
        }, this.Description);
    }
}

using System;

public class SubmenuButton : MenuItem
{
    public MenuTree MenuTree { get; set; }
    public string MenuTitle { get; set; }

    #region constructors
    public SubmenuButton(DisplayMode mode, string name, string title, MenuTree menu, string description = null) : base(mode, name, description)
    {
        this.MenuTitle = title;
        this.MenuTree = menu;
    }
    #endregion

    public override void Tweak(SpectrumMenuAbstract menu)
    {
        menu.TweakAction(this.Name, () => {
            Menu.ShowMenu(MenuTitle, MenuTree, menu, 0);
        }, this.Description);
    }
}

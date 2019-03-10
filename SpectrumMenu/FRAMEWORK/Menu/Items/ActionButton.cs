using System;

public class ActionButton : MenuItem
{
    public Action OnClick { get; set; }
    
    #region constructors
    public ActionButton(DisplayMode mode, string name, Action action, string description = null) : base(mode, name, description)
    {
        this.OnClick = action;
    }
    #endregion
    
    public override void Tweak(SpectrumMenu menu)
    {
        menu.TweakAction(this.Name, this.OnClick, this.Description);
    }
}
using System;

public class CheckBox : MenuItem
{
    public Func<bool> GetValue { get; set; }
    public Action<bool> SetValue { get; set; }

    #region constructors
    public CheckBox(DisplayMode mode, string name, Func<bool> get, Action<bool> set, string description = null) : base(mode, name, description)
    {
        this.GetValue = get;
        this.SetValue = set;
    }

    public CheckBox(DisplayMode mode, string name, bool startvalue, Action<bool> set, string description = null) : this(mode, name, () => { return startvalue; }, set, description)
    { }
    #endregion

    public override void Tweak(SpectrumMenu menu)
    {
        menu.TweakBool(this.Name, this.GetValue(), this.SetValue, this.Description);
    }
}
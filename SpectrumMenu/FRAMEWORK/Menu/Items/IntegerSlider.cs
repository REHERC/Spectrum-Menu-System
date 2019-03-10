using System;

public class IntegerSlider : MenuItem
{
    public int Min { get; set; }
    public int Max { get; set; }
    public Func<int> GetValue { get; set; }
    public Action<int> SetValue { get; set; }
    public int DefaultValue { get; set; }

    #region constructors
    public IntegerSlider(DisplayMode mode, string name, int min, int max, int hint, Func<int> get, Action<int> set, string description = null) : base(mode, name, description)
    {
        this.Min = min;
        this.Max = max;
        this.GetValue = get;
        this.SetValue = set;
        this.DefaultValue = hint;
    }

    public IntegerSlider(DisplayMode mode, string name, int startvalue, Action<int> set, string description = null) : this(mode, name, 0, 1, -1, () => { return startvalue; }, set, description)
    { }

    public IntegerSlider(DisplayMode mode, string name, int startvalue, int min, int max, Action<int> set, string description = null) : this(mode, name, min, max, min - 1, () => { return startvalue; }, set, description)
    { }
    #endregion

    public override void Tweak(SpectrumMenuAbstract menu)
    {
        menu.TweakInt(this.Name, this.GetValue(), this.Min, this.Max, this.DefaultValue, this.SetValue, this.Description);
    }
}

using System;

public class DecimalSlider : MenuItem
{
    public float Min { get; set; }
    public float Max { get; set; }
    public Func<float> GetValue { get; set; }
    public Action<float> SetValue { get; set; }
    public float DefaultValue { get; set; }

    #region constructors
    public DecimalSlider(DisplayMode mode, string name, float min, float max, float hint, Func<float> get, Action<float> set, string description = null) : base(mode, name, description)
    {
        this.Min = min;
        this.Max = max;
        this.GetValue = get;
        this.SetValue = set;
        this.DefaultValue = hint;
    }

    public DecimalSlider(DisplayMode mode, string name, float startvalue, Action<float> set, string description = null) : this(mode, name, 0.0f, 1.0f, float.NaN, () => { return startvalue; }, set, description)
    { }

    public DecimalSlider(DisplayMode mode, string name, float startvalue, float min, float max, Action<float> set, string description = null) : this(mode, name, min, max, float.NaN, () => { return startvalue; }, set, description)
    { }
    #endregion

    public override void Tweak(SpectrumMenu menu)
    {
        menu.TweakFloat(this.Name, this.GetValue(), this.Min, this.Max, this.DefaultValue, this.SetValue, this.Description);
    }
}

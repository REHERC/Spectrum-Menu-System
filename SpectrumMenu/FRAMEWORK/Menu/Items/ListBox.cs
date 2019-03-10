using System;
using System.Collections.Generic;

public class ListBox<T> : MenuItem
{
    public Func<T> GetValue { get; set; }
    public Action<T> SetValue { get; set; }
    public Func<KeyValuePair<string, T>[]> Entries { get; set; }

    #region constructors
    public ListBox(DisplayMode mode, string name, Func<T> get, Action<T> set, Func<KeyValuePair<string, T>[]> entries, string description = null) : base(mode, name, description)
    {
        this.GetValue = get;
        this.SetValue = set;
        this.Entries = entries;
    }

    public ListBox(DisplayMode mode, string name, Func<T> get, Action<T> set, KeyValuePair<string, T>[] entries, string description = null) : this(mode, name, get, set, () => { return entries; }, description)
    { }

    public ListBox(DisplayMode mode, string name, Func<T> get, Action<T> set, Dictionary<string, T> entries, string description = null) : this(mode, name, get, set, entries.ToArray(), description)
    { }
    #endregion

    public override void Tweak(SpectrumMenuAbstract menu)
    {
        menu.TweakEnum<T>(this.Name, this.GetValue, this.SetValue, this.Description, this.Entries());
    }
}
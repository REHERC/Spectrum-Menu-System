using UnityEngine.SceneManagement;

public abstract class MenuItem
{
    public readonly DisplayMode Mode;
    public string Name { get; set; }
    public string Description { get; set; }
    
    protected MenuItem(DisplayMode mode, string name, string description = "")
    {
        this.Name = name;
        this.Description = description;
        this.Mode = mode;
    }

    public abstract void Tweak(SpectrumMenuAbstract menu);

    public enum DisplayMode
    {
        MainMenu = 1,
        PauseMenu = 2,
        Any = 4
    }

    public static DisplayMode GetCurrentMode()
    {
        if (SceneManager.GetActiveScene().name.ToLower() == "mainmenu")
            return DisplayMode.MainMenu;
        return DisplayMode.PauseMenu;
    }
}

static class DisplayModeEx
{
    public static bool Compare(this MenuItem.DisplayMode target, MenuItem.DisplayMode value)
    {
        if (value == MenuItem.DisplayMode.Any)
            return true;
        return target == value;
    }
}
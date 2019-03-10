using Spectrum.API.Interfaces.Systems;

public abstract class SpectrumMenu : SuperMenu
{
    public override string MenuTitleName_ => "Configure Spectrum Plugins";
    public override string Name_ => "Spectrum Settings";
    
    public IManager Manager { get; private set; }
    
    public override bool DisplayInMenu(bool isPauseMenu) => true;

    public SpectrumMenu()
    {
        menuBlueprint_ = Menu.menuBlueprint;
    }

    public void SetManager(IManager manager)
    {
        Manager = manager;
    }

    public override void InitializeVirtual()
    {
        
    }

    public override void OnPanelPop()
    {
        
    }
}
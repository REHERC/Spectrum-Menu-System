using System;
using UnityEngine;

public class AutoMenu : SpectrumMenu
{
    // The menu panel used to display the GUI
    public MenuPanel MenuPanel = null;

    // Just a class to make an update method
    private AutoMenuController controller;

    // Determines if the menu is switching to another page when closing
    public bool PageSwitching { get; private set; } = false;

    #region Description
    private string _Description;
    public string Description
    {
        get
        {
            return _Description;
        }
        set
        {
            _Description = value;
        }
    }
    #endregion
    #region Title
    private string _Title;
    public string Title
    {
        get
        {
            return _Title;
        }
        set
        {
            _Title = value;
        }
    }
    #endregion

    #region Menu Objects
    private GameObject TitleLabel()
    {
        return PanelObject_.transform.Find("MenuTitleTemplate/UILabel - Title").gameObject;
    }

    private GameObject DescriptionLabel()
    {
        return PanelObject_.transform.Find("MenuTitleTemplate/UILabel - Description").gameObject;
    }

    private GameObject OptionsTable()
    {
        return PanelObject_.transform.Find("Options/OptionsTable").gameObject;
    }
    #endregion

    // Input manager to handle key presses (previous/next buttons)
    private InputManager im = null;

    // List of menu entries
    public MenuTree Entries { get; set; } = new MenuTree();

    // Maximum amount of items per page
    const int MaxEntriesPerPage = 9;

    // Currently displayed page (index 0 is page 1)
    public int PageIndex { get; set;} = 0;

    // Number of available pages
    private int PageCount;

    public override void InitializeVirtual()
    {
        im = G.Sys.InputManager_;

        PageCount = (int)Math.Ceiling(Entries.Count / (float)MaxEntriesPerPage);

        DisplayMenu();

        controller = this.PanelObject_.AddComponent<AutoMenuController>();
        controller.menu = this;
    }

    private void DisplayMenu()
    {
        MenuTree currentTree = Entries.GetItems(MenuItem.GetCurrentMode());
        for (int i = PageIndex * MaxEntriesPerPage; i < (PageIndex * MaxEntriesPerPage) + MaxEntriesPerPage; i ++)
        {
            if (i < currentTree.Count)
                currentTree[i].Tweak(this);
            else break;
        }
    }

    public override void OnPanelPop()
    {
        controller.Destroy();
        MenuPanel.Destroy();
        PanelObject_.Destroy();
        this.Destroy();
    }
    
    public void UpdateVirtual()
    {
        G.Sys.MenuPanelManager_.SetBottomLeftActionButton(InputAction.MenuPageUp, "PREVIOUS");
        G.Sys.MenuPanelManager_.SetBottomLeftActionButton(InputAction.MenuPageDown, "NEXT");
        G.Sys.MenuPanelManager_.SetBottomLeftActionButtonEnabled(InputAction.MenuPageUp, Entries.Count > MaxEntriesPerPage);
        G.Sys.MenuPanelManager_.SetBottomLeftActionButtonEnabled(InputAction.MenuPageDown, Entries.Count > MaxEntriesPerPage);

        if (Entries.Count > MaxEntriesPerPage)
        {
            if (im.GetKeyUp(InputAction.MenuPageUp))
            {
                PageIndex -= 1;
                PageIndex = PageIndex < 0 ? PageCount - 1 : PageIndex > PageCount - 1 ? 0 : PageIndex;
                PageSwitching = true;
                MenuPanel.Pop();
            }
            if (im.GetKeyUp(InputAction.MenuPageDown))
            {
                PageIndex += 1;
                PageIndex = PageIndex < 0 ? PageCount - 1 : PageIndex > PageCount - 1 ? 0 : PageIndex;
                PageSwitching = true;
                MenuPanel.Pop();
            }
        }
        
        Description = $"Page {PageIndex + 1} / {PageCount}";
        
        TitleLabel()?.SetActive(true);
        UILabel TitleLabelObject = TitleLabel().GetComponent<UILabel>();
        if (TitleLabelObject)
            TitleLabelObject.text = Title;

        DescriptionLabel()?.SetActive(true);
        UILabel DescriptionLabelObject = DescriptionLabel().GetComponent<UILabel>();
        if (DescriptionLabelObject)
            DescriptionLabelObject.text = Description;
    }
}

public class AutoMenuController : MonoBehaviour
{
    public AutoMenu menu { get; set; }

    void Update()
    {
        if (menu != null && menu.PanelObject_.activeInHierarchy && menu.MenuPanel.IsTop_)
            menu.UpdateVirtual();
    }
}
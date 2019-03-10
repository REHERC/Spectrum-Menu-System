using System.Collections.Generic;

public class MenuTree : List<MenuItem>
{
    public MenuTree GetItems(MenuItem.DisplayMode mode)
    {
        MenuTree tree = new MenuTree();

        foreach (var item in this)
            if (MenuItem.GetCurrentMode().Compare(item.Mode))
                tree.Add(item);
        
        return tree;
    }
}

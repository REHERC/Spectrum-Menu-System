using System;
using UnityEngine;

public static class Menu
{
    public static GameObject menuBlueprint;

    public static MenuTree menuTree = new MenuTree();

    public static string GenerateId()
    {
        Guid g = Guid.NewGuid();
        string guid = Convert.ToBase64String(g.ToByteArray());
        guid = guid.Replace("=", "");
        guid = guid.Replace("+", "");
        guid = guid.Replace("/", "");
        guid = guid.Replace("\\", "");

        return guid;
    }
}
using Harmony;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using System;
using System.Reflection;

namespace MenuSystem
{
    public class Entry : IPlugin
    {
        public void Initialize(IManager manager, string ipcIdentifier)
        {
            try
            {
                HarmonyInstance Harmony = HarmonyInstance.Create("com.spectrum.menusystem");
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception)
            { }
        }
    }
}

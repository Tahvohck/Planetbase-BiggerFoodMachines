using Planetbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;

namespace Tahvohck_Mods
{
    public class BFM_Main : IMod
    {
        public void Init()
        {
            TahvUtil.Log("Initialized.");
            ZZZ_Modhooker.PreResetEvent += Setup;
#if DEBUG
            ZZZ_Modhooker.PostResetEvent += Runcheck;
#endif
        }

        public void Update() { }

        public void Setup(object sender, EventArgs e)
        {
            new Harmony(typeof(BFM_Main).FullName).PatchAll();
            TahvUtil.Log("Patched.");
        }

        public void Runcheck(object sender, EventArgs evArgs)
        {
            MealMaker mm = (MealMaker)TypeList<ComponentType, ComponentTypeList>.find<MealMaker>();
            TahvUtil.Log($"MealMaker slots: {mm.getEmbeddedResourceCount()}");
        } 
    }


    [HarmonyPatch(typeof(MealMaker), MethodType.Constructor)]
    public class Patches
    {
        [HarmonyPostfix]
        public static void MoreMealMakerSlots(MealMaker __instance)
        {
            __instance.mEmbeddedResourceCount = 12;
        }
    }
}

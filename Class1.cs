using Planetbase;
using System;
using System.Reflection;
using UnityModManagerNet;

namespace Tahvohck_Mods
{
    using EntryData = UnityModManager.ModEntry;
    using ModLogger = UnityModManager.ModEntry.ModLogger;

    public class BFM_Main
    {
        internal static ModLogger Logger;
        internal static Action<EntryData, float> defaultOnUpdate;

        [LoaderOptimization(LoaderOptimization.NotSpecified)]
        public static void Init(EntryData data)
        {
            Logger = data.Logger;
            defaultOnUpdate = data.OnUpdate;
            data.OnUpdate = Update;
        }

        public static void Update(EntryData data, float tDelta)
        {
            MealMaker mm = ComponentTypeList.find<MealMaker>() as MealMaker;
            typeof(MealMaker)
                    .GetField("mEmbeddedResourceCount", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(mm, 12);
#if DEBUG
            Logger.Log($"MealMaker slots: {mm.getEmbeddedResourceCount()}");
#endif
            data.OnUpdate = defaultOnUpdate;
        }
    }
}

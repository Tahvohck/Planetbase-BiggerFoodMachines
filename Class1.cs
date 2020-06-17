using Planetbase;
using System;
using System.Reflection;

namespace Tahvohck_Mods
{

    public class BFM_Main
    {

        [LoaderOptimization(LoaderOptimization.NotSpecified)]
        public static void Init()
        {
            TahvohckUtil.FirstUpdate += Update;
        }

        public static void Update()
        {
            MealMaker mm = ComponentTypeList.find<MealMaker>() as MealMaker;
            typeof(MealMaker)
                .GetField("mEmbeddedResourceCount", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(mm, 12);
        }
    }
}

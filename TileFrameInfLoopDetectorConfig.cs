using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TileFrameInfLoopDetector
{
    [Label("$Mods.TileFrameInfLoopDetector.Configs.Main.Title")]
    public class TileFrameInfLoopDetectorConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$Mods.TileFrameInfLoopDetector.Configs.Main.SafeMode_Label")]
        [Tooltip("$Mods.TileFrameInfLoopDetector.Configs.Main.SafeMode_Tooltip")]
        [DefaultValue(false)]
        public bool safeMode;

        [Label("$Mods.TileFrameInfLoopDetector.Configs.Main.UpperLimit_Label")]
        [Tooltip("$Mods.TileFrameInfLoopDetector.Configs.Main.UpperLimit_Tooltip")]
        [DefaultValue(100)]
        [Range(10, 1000)]
        public int upperLimit;
    }
}

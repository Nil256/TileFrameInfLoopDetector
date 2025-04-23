using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace TileFrameInfLoopDetector
{
	public class TileFrameInfLoopDetector : Mod
	{
        private static bool _loadingWorld = false;
        private static readonly Dictionary<Point, int> _calledCount = new Dictionary<Point, int>(8400 * 2400);
        private static readonly HashSet<Point> _infLoopTiles = new HashSet<Point>();

        internal static IReadOnlySet<Point> InfLoopTiles => _infLoopTiles;

        public override void Load()
        {
            On.Terraria.IO.WorldFile.LoadWorld += HackLoadWorld;
            On.Terraria.WorldGen.TileFrame += HackTileFrame;
        }

        private void HackLoadWorld(On.Terraria.IO.WorldFile.orig_LoadWorld orig, bool loadFromCloud)
        {
            _loadingWorld = true;
            _calledCount.Clear();
            _infLoopTiles.Clear();
            orig(loadFromCloud);
            _loadingWorld = false;
        }

        private void HackTileFrame(On.Terraria.WorldGen.orig_TileFrame orig, int i, int j, bool resetFrame, bool noBreak)
        {
            if (!_loadingWorld)
            {
                orig(i, j, resetFrame, noBreak);
                return;
            }
            Point tilePosition = new Point(i, j);
            if (!_calledCount.ContainsKey(tilePosition))
            {
                _calledCount.Add(tilePosition, 0);
            }
            _calledCount[tilePosition]++;
            if (_calledCount[tilePosition] >= 100)
            {
                if (!_infLoopTiles.Contains(tilePosition))
                {
                    _infLoopTiles.Add(tilePosition);
                }
                return;
            }
            orig(i, j, resetFrame, noBreak);
        }

        public override void Unload()
        {
            On.Terraria.IO.WorldFile.LoadWorld -= HackLoadWorld;
            On.Terraria.WorldGen.TileFrame -= HackTileFrame;
        }
    }
}
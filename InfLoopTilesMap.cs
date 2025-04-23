using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;

namespace TileFrameInfLoopDetector
{
    public class InfLoopTilesMap : ModMapLayer
    {
        private Asset<Texture2D> _exclamationMark;

        public override void Draw(ref MapOverlayDrawContext context, ref string text)
        {
            IReadOnlySet<Point> infLoopTiles = TileFrameInfLoopDetector.InfLoopTiles;
            foreach (Point tile in infLoopTiles)
            {
                _exclamationMark ??= ModContent.Request<Texture2D>("TileFrameInfLoopDetector/Textures/Exclamation");
                context.Draw(_exclamationMark.Value, tile.ToVector2(), Color.White, new SpriteFrame(1, 1, 0, 0), 1f, 1f, Alignment.Center);
            }
        }
    }
}

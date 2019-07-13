﻿using BPO.Minijam32;
using BPO.Minijam32.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Amasuri.Reusable.Graphics
{
    /// <summary>
    /// Calls other draw things. Doesn't draw anything on it's own.
    /// </summary>
    public class ScreenPool : IDrawArranger
    {
        public enum ScreenState { Start, Playing, EndGame }
        public ScreenState screenState { get; private set; }

        private MouseState _mouse;
        private MouseState _oldMouse;
        private KeyboardState _key;
        private KeyboardState _oldKey;

        private Color backgroundDirtColor;

        public ScreenPool(Minijam32 game)
        {
            this.screenState = ScreenState.Playing;
            this.backgroundDirtColor = new Color(57, 42, 28);
        }

        /// <summary>
        /// Main draw cycle. Calls other drawers.
        /// </summary>
        public void CallDraws(Minijam32 game, SpriteBatch batch, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(backgroundDirtColor);
            batch.Begin(samplerState: SamplerState.PointClamp);

            if (screenState == ScreenState.Start)
            {
            }
            else if (screenState == ScreenState.Playing)
            {
                game.levelData.DrawBelow(game, batch);
                PlayerDrawer.DrawCurrentState(batch, PlayerDataManager.tilePosition);
                game.levelData.DrawAbove(game, batch);
            }
            else if (screenState == ScreenState.EndGame)
            {
            }

            batch.End();
        }

        public void CallGuiControlUpdates(Minijam32 game)
        {
            this._key = Keyboard.GetState();
            this._mouse = Mouse.GetState();

            //code
            if (screenState == ScreenState.Start)
            {
            }
            else if (screenState == ScreenState.Playing)
            {
            }
            else if (screenState == ScreenState.EndGame)
            {
            }

            this._oldKey = this._key;
            this._oldMouse = this._mouse;
        }
    }
}

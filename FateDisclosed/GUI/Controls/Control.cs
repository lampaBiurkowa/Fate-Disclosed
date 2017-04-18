/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using SFML.Graphics;
using SFML.System;

namespace FateDisclosed.GUI.Controls
{
    public abstract class Control
    {
        protected RenderWindow win;
        public Vector2f Position { get; set; }

        public Control(RenderWindow win)
        {
            this.win = win;
        }

        public abstract void Update();
    }
}

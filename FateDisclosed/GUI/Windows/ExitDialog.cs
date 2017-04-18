/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using FateDisclosed.Screens;
using SFML.Graphics;

namespace FateDisclosed.GUI.Windows
{
    class ExitDialog:DialogWindow
    {
        Text description;

        public ExitDialog(AbstractScreen parentScreen) : base(parentScreen)
        {
            description = new Text("Czy na pewno chcesz wyjść z gry?", AssetsManager.GetFont("fabada"), 23);
            description.Position = new SFML.System.Vector2f(500 / 2 - description.GetGlobalBounds().Width / 2, 60);
            label = "Wyjście";
        }

        public new void DrawOnWindow()
        {
            base.DrawOnWindow();
            windowTexture.Draw(description);
        }
    }
}

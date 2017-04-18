/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using FateDisclosed.GUI.Controls;
using FateDisclosed.Screens;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace FateDisclosed.GUI.Windows
{
    class ExitDialog:DialogWindow
    {
        Text description;
        Button Yes;
        Button No;

        public ExitDialog(AbstractScreen parentScreen) : base(parentScreen)
        {
            description = new Text("Czy na pewno chcesz wyjść z gry?", AssetsManager.GetFont("fabada"), 23);
            description.Position = new SFML.System.Vector2f(500 / 2 - description.GetGlobalBounds().Width / 2, 60);
            label = "Wyjście";
            Yes = new Button(parentScreen.app.win, AssetsManager.GetTexture("small button"), "Tak", AssetsManager.GetFont("fabada"));
            No = new Button(parentScreen.app.win, AssetsManager.GetTexture("small button"), "Nie", AssetsManager.GetFont("fabada"));

            Yes.Position = new SFML.System.Vector2f(17, 239);
            No.Position = new SFML.System.Vector2f(337, 239);

            Vector2f relativeTo = window.Position;
            relativeTo.X -= window.GetLocalBounds().Width / 2;
            relativeTo.Y -= window.GetLocalBounds().Height / 2;
            System.Console.WriteLine(window.GetGlobalBounds().Width / 2);
            Yes.realPosition = new FloatRect(Yes.Position+relativeTo, (Vector2f)Yes.buttonSprite.Texture.Size);
            No.realPosition = new FloatRect(No.Position + relativeTo, (Vector2f)No.buttonSprite.Texture.Size);

            Yes.TextHeightFix = -3;
            No.TextHeightFix = -3;
        }

        public new void Update(float deltaTime)
        {
            base.Update(deltaTime);
            Yes.Update();
            No.Update();

            if(Yes.Pressed())
            {
                parentScreen.app.win.Close();
            }
            else if(No.Pressed())
            {
                show = false;
            }
        }

        public new void DrawOnWindow()
        {
            base.DrawOnWindow();
            windowTexture.Draw(description);
            windowTexture.Draw(Yes);
            windowTexture.Draw(No);
        }
    }
}

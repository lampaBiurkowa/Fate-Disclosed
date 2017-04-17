/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using SFML.Graphics;
using SFML.System;

namespace FateDisclosed.Screens
{
    class SplashScreen : AbstractScreen
    {
        float progressRotation = 0;

        AssetsManager splashScreenAssets;
        AssetsManager mainMenuAssets;
        Clock clock;

        Sprite logo;
        Sprite progressCircle;

        public SplashScreen(AppCore app) : base(app)
        {
            splashScreenAssets = new AssetsManager();
            mainMenuAssets = new AssetsManager();
            clock = new Clock();
        }

        public override void Draw()
        {
            app.win.Draw(logo);
            app.win.Draw(progressCircle);
        }

        public override void Start()
        {
            this.app.clearColor = new Color(0, 51, 51);
            //Load splash screen package
            splashScreenAssets.LoadPackage("res/textures/gui.fdp");
            splashScreenAssets.LoadPackage("res/textures/menu.fdp");
            logo = new Sprite(splashScreenAssets.GetTexture("logo"));
            progressCircle = new Sprite(splashScreenAssets.GetTexture("loading"));

            logo.Position = new Vector2f(app.win.Size.X / 2 - logo.GetGlobalBounds().Width / 2, app.win.Size.Y / 2 - logo.GetGlobalBounds().Height / 2);
            progressCircle.Origin = new Vector2f(17, 17);
            progressCircle.Position = new Vector2f(app.win.Size.X / 2, app.win.Size.Y / 2 + 100);
            //Load menu package
            mainMenuAssets.LoadPackage("res/textures/gui.fdp");
            mainMenuAssets.LoadPackage("res/textures/menu.fdp");
            mainMenuAssets.LoadFontFromFile("arial", new Font("res/fonts/CaprKFont 2.ttf"));
        }
            
        public override void Update(float deltaTime)
        {
            progressRotation += 300 * deltaTime;
            progressCircle.Rotation = progressRotation;
            if (clock.ElapsedTime.AsSeconds() > 3)
            {
                app.manager.SetScreen(new MainMenuScreen(this.app, mainMenuAssets));
            }
        }
    }
}

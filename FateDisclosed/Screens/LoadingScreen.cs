/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using SFML.Graphics;
using SFML.System;
using System.Threading;

namespace FateDisclosed.Screens
{
    class LoadingScreen : AbstractScreen
    {
        Clock clock;
        MoviePlayer loadingAnimation;

        Thread loadingThread;

        public LoadingScreen(AppCore app, MoviePlayer movie) : base(app)
        {
            clock = new Clock();
            loadingAnimation = movie;
        }

        public override void Draw()
        {
            app.win.Draw(loadingAnimation);
        }

        public override void Start()
        {
            loadingAnimation.Play();
            loadingThread = new Thread(LoadAssets);
            loadingThread.Start();
           // app.view = app.win.DefaultView;
            this.app.clearColor = new Color(0, 51, 51);
            
        }

        private void LoadingDone()
        {
            loadingAnimation.Stop();
            app.manager.SetScreen(new MainMenuScreen(app));
        }

        private void LoadAssets()
        {
            //Load menu package
            AssetsManager.LoadFontPackage("res/fonts/fonts.fdp");
            AssetsManager.LoadTexturePackage("res/textures/textures.fdp");
        }

        public override void Update(float deltaTime)
        {
            loadingAnimation.Update();
            if(!loadingThread.IsAlive && clock.ElapsedTime.AsSeconds() > 14)
            {
                LoadingDone();
            }
        }
    }
}

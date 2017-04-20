/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
***/
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using FateDisclosed.Screens;

namespace FateDisclosed
{
    public class AppCore
    {
        public Vector2i ScreenSize { get; private set; }
        public readonly Vector2i virtualResolution;
        public RenderWindow win;
        public View view;
        public ScreenManager manager;
        public Color clearColor;
        public AssetsManager assetsManager;

        public AppCore(Vector2i screenSize)
        {
            this.ScreenSize = screenSize;
            virtualResolution = new Vector2i(1600, 900);

            win = new RenderWindow(new SFML.Window.VideoMode((uint)screenSize.X, (uint)screenSize.Y), "Fate Disclosed",SFML.Window.Styles.Fullscreen, new ContextSettings(0, 0, 2));
            win.SetVerticalSyncEnabled(true);
            win.Closed += Win_Closed;
            win.Resized += Win_Resized;
            win.SetIcon(256, 256, new Image("res/icon.png").Pixels);
            clearColor = new Color(0, 0, 0);

            assetsManager = new AssetsManager();
            manager = new ScreenManager();
        }

        private void Win_Resized(object sender, SizeEventArgs e)
        {
            view.Size = new SFML.System.Vector2f(virtualResolution.X, virtualResolution.Y);
            view.Center = new SFML.System.Vector2f(virtualResolution.X / 2, virtualResolution.Y / 2);
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }

        public void Start()
        {
            view = new View(new FloatRect(0, 0, ScreenSize.X, ScreenSize.Y));
            win.SetView(view);
            manager.SetScreen(new Screens.SplashScreen(this));
        }

        public void Run()
        {
            while(win.IsOpen)
            {
                win.DispatchEvents();
                win.SetView(view);
                win.Clear(clearColor);
                manager.Update();
                manager.Draw();
                win.Display();
            }
        }

        ~AppCore()
        {
            assetsManager.Dispose();
        }
    }
}

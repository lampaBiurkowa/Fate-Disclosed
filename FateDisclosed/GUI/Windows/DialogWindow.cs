/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using FateDisclosed.Screens;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace FateDisclosed.GUI.Windows
{
    public abstract class DialogWindow : Drawable
    {
        protected RenderTexture windowTexture;
        protected AbstractScreen parentScreen;
        protected Sprite window;
        protected Sprite border;
        Text title;

        float time = 0;

        Input.MouseInput mouseInput;

        protected string label
        {
            get { return title.DisplayedString; }
            set
            {
                title.DisplayedString = value;
            }
        }


        protected bool show = false;

        protected DialogWindow(AbstractScreen parentScreen)
        {
            this.parentScreen = parentScreen;

            windowTexture = new RenderTexture(500, 300);
            window = new Sprite(windowTexture.Texture);
        
            window.Origin = new Vector2f(250, 150);
            window.Position = new Vector2f(parentScreen.app.virtualResolution.X / 2, parentScreen.app.virtualResolution.Y / 2);
            window.Scale = new Vector2f(0.0f, 0.0f);
            window.Color = new Color(255, 255, 255, 0);

            border = new Sprite(AssetsManager.GetTexture("window"));
            //border.Origin = new Vector2f(250, 150);
            //border.Position = new Vector2f(window.GetLocalBounds().Width / 2, window.GetLocalBounds().Height / 2);

            title = new Text("", AssetsManager.GetFont("fabada"), 21);
            title.Position = new Vector2f(7,10);

            mouseInput = new Input.MouseInput();
        }

        public void Show()
        {
            show = true;
        }

        public void Update(float deltaTime)
        {
            time += deltaTime;
            if (time > 0.015)
            {
                if (show)
                {
                    Vector2i mousePosition = Mouse.GetPosition(parentScreen.app.win);
                    mousePosition = (Vector2i)parentScreen.app.win.MapPixelToCoords(mousePosition, parentScreen.app.view);

                    if (window.Scale.X < 1.0f)
                    {
                        window.Scale = new Vector2f(window.Scale.X + 0.1f, window.Scale.Y + 0.1f);
                        window.Color = new Color(255, 255, 255, Convert.ToByte(window.Color.A + 25.4));
                    }

                    if (mouseInput.MousePressed(SFML.Window.Mouse.Button.Left) && window.Scale.X > 0.9f && !window.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                    {
                        show = false;
                    }
                }
                else
                {
                    if (window.Scale.X > 0.1f)
                    {
                        window.Scale = new Vector2f(window.Scale.X - 0.1f, window.Scale.Y - 0.1f);
                        window.Color = new Color(255, 255, 255, Convert.ToByte(window.Color.A - 25.4));
                    }
                }
                time -= 0.015f;
            }
        }

        public void DrawOnWindow()
        {
            windowTexture.Clear(Color.Transparent);
            windowTexture.Draw(border);
            windowTexture.Draw(title);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            windowTexture.Display();
            target.Draw(window);
        }
    }
}

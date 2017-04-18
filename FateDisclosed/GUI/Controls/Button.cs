/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;

namespace FateDisclosed.GUI.Controls
{
    public class Button : Control, Drawable
    {
        public Sprite buttonSprite { get; private set; }
        private Text text;
        private Input.MouseInput input;
        public float TextHeightFix = 0;
        public FloatRect realPosition = new FloatRect();

        public Button(RenderWindow window, Texture texture,string label, Font font, uint fontSize = 20) : base(window)
        {
            input = new Input.MouseInput();
            buttonSprite = new Sprite(texture);
            text = new Text(label, font, fontSize);
        }

        public override void Update()
        {
            text.Position = new Vector2f(buttonSprite.Position.X + (buttonSprite.GetGlobalBounds().Width / 2 - text.GetGlobalBounds().Width / 2),
                buttonSprite.Position.Y + (buttonSprite.GetGlobalBounds().Height / 2 - text.GetGlobalBounds().Height / 2) + TextHeightFix);

            buttonSprite.Position = this.Position;

            if (MouseOn())
            {
                buttonSprite.Color = new Color(200, 200, 200);
            }
            else
            {
                buttonSprite.Color = new Color(255, 255, 255);
            }
        }

        public bool MouseOn()
        {
            bool mouseOn = false;
            Vector2i mouse = Mouse.GetPosition(win);
            Vector2f mousePos = win.MapPixelToCoords(Mouse.GetPosition(win), win.GetView());

            FloatRect buttonBounds = buttonSprite.GetGlobalBounds();
            if(realPosition != new FloatRect())
            {
                buttonBounds = realPosition;
            }

            if (buttonBounds.Contains(mousePos.X, mousePos.Y)) 
            {
                mouseOn = true;
            }

            return mouseOn;
        }

        public bool Pressed(Mouse.Button button = Mouse.Button.Left)
        {
            bool pressed = false;

            if (input.MousePressed(button))
            {
                if(MouseOn())
                {
                    pressed = true;
                }
            }

            return pressed;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(buttonSprite);
            target.Draw(text);
        }
    }
}

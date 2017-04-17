/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace FateDisclosed
{
    public class AssetsManager
    {
        Dictionary<string, Texture> Textures;
        Dictionary<string, Font> Fonts;

        public AssetsManager()
        {
            Textures = new Dictionary<string, Texture>();
            Fonts = new Dictionary<string, Font>();
        }

        public Texture GetTexture(string name)
        {
            Texture t;
            if(Textures.TryGetValue(name,out t)==false)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load texture " + name + ".", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return t;
        }

        public Font GetFont(string name)
        {
            Font f;
            if (Fonts.TryGetValue(name, out f) == false)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load font " + name + ".", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return f;
        }

        public void LoadTexture(string name, Texture texture)
        {
            if (!Textures.ContainsKey(name))
            {
                Textures.Add(name, texture);
            }
            else
            {
                Console.WriteLine("Failed to load texture " + name + ". Reason: texture exist.");
            }
        }

        public void LoadFontFromFile(string name, Font font)
        {
            if (!Fonts.ContainsKey(name))
            {
                Fonts.Add(name, font);
            }
            else
            {
                Console.WriteLine("Failed to load font " + name + ". Reason: font exist.");
            }
        }

        public void LoadPackage(string packagePath)
        {
            ZipReader zip = new ZipReader(packagePath);
            StreamReader reader = zip.LoadTextStream("package info.txt");
            string line = "";
            while(line != null)
            {
                line = reader.ReadLine();
                if(line != null)
                {
                    int separator = line.IndexOf(":");
                    string assetPath = line.Substring(0, separator);
                    string assetName = line.Substring(separator + 1, line.Length - separator - 1);
                    LoadTexture(assetName, zip.LoadTexture(assetPath));
                }
            }
        }

        public void Dispose()
        {
            foreach(KeyValuePair<string, Texture> texture in Textures)
            {
                texture.Value.Dispose();
            }
            foreach (KeyValuePair<string, Font> font in Fonts)
            {
                font.Value.Dispose();
            }
        }
    }
}

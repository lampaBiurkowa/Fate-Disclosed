/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using SFML.Graphics;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.IO;

namespace FateDisclosed
{
    public static class AssetsManager
    {
        static Dictionary<string, Texture> Textures = new Dictionary<string, Texture>();
        static Dictionary<string, Font> Fonts = new Dictionary<string, Font>();
        static Dictionary<string, SoundBuffer> SBuffers = new Dictionary<string, SoundBuffer>();
        static Dictionary<string, Music> Musics = new Dictionary<string, Music>();

        public static Texture GetTexture(string name)
        {
            Texture t;
            if(Textures.TryGetValue(name,out t)==false)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load texture " + name + ".", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return t;
        }

        public static Font GetFont(string name)
        {
            Font f;
            if (Fonts.TryGetValue(name, out f) == false)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load font " + name + ".", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return f;
        }


        public static Music GetMusic(string name)
        {
            Music m;
            if (Musics.TryGetValue(name, out m) == false)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load music " + name + ".", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return m;
        }

        public static SoundBuffer GetSBuffer(string name)
        {
            SoundBuffer sb;
            if (SBuffers.TryGetValue(name, out sb) == false)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load sound buffer " + name + ".", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return sb;
        }
        public static void LoadTexture(string name, Texture texture)
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

        public static void LoadFont(string name, Font font)
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

        public static void LoadMusic(string name, Music music)
        {
            if (!Fonts.ContainsKey(name))
            {
                Musics.Add(name, music);
            }
            else
            {
                Console.WriteLine("Failed to load music " + name + ". Reason: music exist.");
            }
        }

        public static void LoadSBuffer(string name, SoundBuffer sBuffer)
        {
            if (!Fonts.ContainsKey(name))
            {
                SBuffers.Add(name, sBuffer);
            }
            else
            {
                Console.WriteLine("Failed to load sound buffer " + name + ". Reason: sound exist.");
            }
        }
        public static void LoadTexturePackage(string packagePath)
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

        public static void LoadFontPackage(string packagePath)
        {
            ZipReader zip = new ZipReader(packagePath);
            StreamReader reader = zip.LoadTextStream("package info.txt");
            string line = "";
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    int separator = line.IndexOf(":");
                    string assetPath = line.Substring(0, separator);
                    string assetName = line.Substring(separator + 1, line.Length - separator - 1);
                    LoadFont(assetName, zip.LoadFont(assetPath));
                }
            }
        }

        public static void LoadMusicPackage(string packagePath)
        {
            ZipReader zip = new ZipReader(packagePath);
            StreamReader reader = zip.LoadTextStream("package info.txt");
            string line = "";
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    int separator = line.IndexOf(":");
                    string assetPath = line.Substring(0, separator);
                    string assetName = line.Substring(separator + 1, line.Length - separator - 1);
                    LoadMusic(assetName, zip.LoadMusic(assetPath));
                }
            }
        }

        public static void LoadSBufferPackage(string packagePath)
        {
            ZipReader zip = new ZipReader(packagePath);
            StreamReader reader = zip.LoadTextStream("package info.txt");
            string line = "";
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    int separator = line.IndexOf(":");
                    string assetPath = line.Substring(0, separator);
                    string assetName = line.Substring(separator + 1, line.Length - separator - 1);
                    LoadSBuffer(assetName, zip.LoadSBuffer(assetPath));
                }
            }
        }

        public static void Dispose()
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

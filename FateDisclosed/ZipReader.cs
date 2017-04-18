/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/ 
using SFML.Graphics;
using SFML.Audio;
using System.IO;
using System.IO.Compression;

namespace FateDisclosed
{
    class ZipReader
    {
        ZipArchive zip;

        public ZipReader(string pathToZip)
        {
            zip = ZipFile.Open(pathToZip, ZipArchiveMode.Read);
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public Texture LoadTexture(string textureName)
        {
            Texture texture;

            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.Name == textureName)
                {
                    System.IO.Stream s = entry.Open();
                    System.IO.StreamReader reader = new System.IO.StreamReader(s);
                    byte[] texcode = ReadFully(s);

                    texture = new Texture(texcode);   
                     return texture;
                }
            }

            return null;
        }

        public Font LoadFont(string fontName)
        {
            Font font;

            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.Name == fontName)
                {
                    System.IO.Stream s = entry.Open();
                    System.IO.StreamReader reader = new System.IO.StreamReader(s);
                    byte[] texcode = ReadFully(s);

                    font = new Font(texcode);
                    return font;
                }
            }

            return null;
        }

        public string LoadText(string fileName)
        {
            string text = "";

            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.Name == fileName)
                {
                    System.IO.Stream s = entry.Open();
                    System.IO.StreamReader reader = new System.IO.StreamReader(s);
                    text = reader.ReadToEnd();
                }
            }

            return text;
        }

        public StreamReader LoadTextStream(string fileName)
        {

            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.Name == fileName)
                {
                    System.IO.Stream s = entry.Open();
                    return new System.IO.StreamReader(s);
                }
            }

            return null;
        }

        public Music LoadMusic(string fileName)
        {
            Music music;
            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.Name == fileName)
                {
                    System.IO.Stream s = entry.Open();
                    System.IO.StreamReader reader = new System.IO.StreamReader(s);
                    byte[] texcode = ReadFully(s);

                    music = new Music(texcode);
                    return music;
                }
            }

            return null;
        }

        public SoundBuffer LoadSBuffer(string fileName)
        {
            SoundBuffer sbuffer;
            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.Name == fileName)
                {
                    System.IO.Stream s = entry.Open();
                    System.IO.StreamReader reader = new System.IO.StreamReader(s);
                    byte[] texcode = ReadFully(s);

                    sbuffer = new SoundBuffer(texcode);
                    return sbuffer;
                }
            }

            return null;
        }
    }
}

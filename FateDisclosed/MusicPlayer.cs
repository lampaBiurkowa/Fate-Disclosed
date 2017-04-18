/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using System;
using FateDisclosed.Screens;
using SFML.Graphics;
using SFML.Audio;

namespace FateDisclosed
{
    public class MusicPlayer
    {
        Music music;
        SoundBuffer sbuffer;
        Sound sound;
        bool infoBool;
        int volume;
        public MusicPlayer(string path,bool isMusic=true)
        {
            infoBool=isMusic;
            if(isMusic==true)
            {
                music=AssetsManager.GetMusic(path);
                sbuffer=null;
                sound=null;
            }
            else
            {
                music=null;
                sbuffer=AssetsManager.GetSBuffer(path);
                sound.SoundBuffer=sbuffer;
            }
        }
        public void updateVolume()
        {
            if(infoBool==true)
                music.Volume=volume;
            else
                sound.Volume=volume;
        }
        public void Play()
        {
            if(infoBool==true)
                music.Play();
            else
                sound.Play();
        }

        public void Stop()
        {
            if(infoBool==true)
                music.Stop();
            else
                sound.Stop();
        }

        public void Pause()
        {
            if(infoBool==true)
                music.Pause();
            else
                sound.Pause();
        }
        public int Volume
        {
            get { return volume; }
            set { volume=value; }
        }
        public void PauseMusic()
        {
            music.Pause();
        }
    }
}

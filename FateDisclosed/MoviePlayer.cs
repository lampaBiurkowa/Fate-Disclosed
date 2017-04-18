/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 * This source uses MotionNET
 * which is released under the zlib/png license.
 * Copyright (C) 2015 by Zachariah Brown
 * *********
 ***/
using System;
using FateDisclosed.Screens;
using MotionNET;
using SFML.Graphics;

namespace FateDisclosed
{
    public class MoviePlayer:Drawable
    {
        public DataSource movie { get; private set; }
        VideoPlayback video;
        AudioPlayback audio;
        AbstractScreen screen;

        public MoviePlayer(string path, AbstractScreen parentScreen, bool playSound = true)
        {
            screen = parentScreen;

            movie = new DataSource();
            movie.LoadFromFile(path, EnableAudio:playSound);
            video = new VideoPlayback(movie);
            audio = new AudioPlayback(movie);
        }

        public void Play()
        {
            movie.Play();
        }

        public void Stop()
        {
            movie.Stop();
        }

        public void Pause()
        {
            movie.Pause();
        }

        public void Update()
        {
            movie.Update();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(video);
        }
    }
}

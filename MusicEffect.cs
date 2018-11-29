using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace UIT_Snake
{
    class SoundEffect
    {
        WindowsMediaPlayer sound;

        public SoundEffect(string _filePath)
        {
            sound = new WindowsMediaPlayer();
            sound.URL = _filePath;
            sound.controls.play();
        }

        public void Play()
        {
            sound.controls.play();
        }

        public void Stop()
        {
            sound.controls.stop();
        }

        public void Pause()
        {
            sound.controls.pause();
        }

        public void Resume()
        {
            if (sound.status == "Paused")
                sound.controls.play();
        }
    }
}


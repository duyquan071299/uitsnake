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
        WindowsMediaPlayer  _sound,_Eaten, _Dead;
        public SoundEffect()
        {
        }
        public SoundEffect(string _filePath)
        {
            _sound = new WindowsMediaPlayer();
            _sound.URL = _filePath;
            _sound.controls.play();
        }
        public void PauseSound()
        {
            _sound.controls.pause();   
        }
        public void PlaySound()
        {
            _sound.controls.play();
        }
        public void Eat ()
        {
            _Eaten = new WindowsMediaPlayer();
            _Eaten.URL = Form1.FileLocation + "\\sound\\Eat.wav";
            _Eaten.controls.play();
        }
        public void Dead()
        {
            _Dead = new WindowsMediaPlayer();
            _Dead.URL = Form1.FileLocation + "\\sound\\lose.flac";
            _Dead.controls.play();
        }
    }
}


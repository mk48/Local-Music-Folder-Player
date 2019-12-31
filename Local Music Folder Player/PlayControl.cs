using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Local_Music_Folder_Player
{
    public static class PlayControl
    {
        private static MediaPlayer mediaPlayer;

        static PlayControl()
        {
            mediaPlayer = new MediaPlayer();
        }

        public static void Play(string filePath)
        {
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(filePath));
            mediaPlayer.Play();
        }

        public static void Stop()
        {
            mediaPlayer.Stop();
        }
    }
}

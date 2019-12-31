using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Local_Music_Folder_Player
{
    public class MusicFile
    {
        public string FilePath { get; private set; }
        public string FileName { get; private set; }

        public RelayCommand PlayButtonClickCommand
        {
            get
            {
                return new RelayCommand(this.PlayButtonClick, o => true);
            }
        }

        public MusicFile(string filePath)
        {
            this.FilePath = filePath;
            this.FileName = Path.GetFileName(filePath);
        }

        private void PlayButtonClick(object parameter)
        {
            PlayControl.Play(this.FilePath);
        }
    }
}

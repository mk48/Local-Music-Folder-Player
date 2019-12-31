using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Music_Folder_Player
{
    public class FolderPlayer: INotifyPropertyChanged
    {
        private List<MusicFile> AllMusicFiles;
        private string searchText;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MusicFile> MusicFiles { get; set; }

        public RelayCommand StopClickCommand
        {
            get
            {
                return new RelayCommand(this.StopButtonClick, o => true);
            }
        }

        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                this.searchText = value;

                this.MusicFiles = new ObservableCollection<MusicFile>( this.AllMusicFiles.Where(m => m.FileName.ToLower().Contains(value.ToLower() )));
                this.OnPropertyChanged(nameof(this.SearchText));
                this.OnPropertyChanged(nameof(this.MusicFiles));
            }
        }

        public FolderPlayer()
        {
            MusicFiles = new ObservableCollection<MusicFile>();

            string[] allMusicFolders = File.ReadAllLines("MusicFolderLocations.txt");

            //loop through all folders
            foreach (string musicFolder in allMusicFolders)
            {
                string[] allMusicFilesInFolder = Directory.GetFiles(musicFolder, "*.mp3", SearchOption.AllDirectories);

                //loop through all files in that folder
                foreach (string musicFilePath in allMusicFilesInFolder)
                {
                    MusicFiles.Add(new MusicFile(musicFilePath));
                }
            }

            this.AllMusicFiles = this.MusicFiles.ToList();
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void StopButtonClick(object parameter)
        {
            PlayControl.Stop();
        }
    }
}

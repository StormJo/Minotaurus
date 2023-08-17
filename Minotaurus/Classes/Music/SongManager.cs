using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Music
{
    internal class SongManager
    {
        private static SongManager instance;
        public static SongManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SongManager();
                }
                return instance;
            }
        }

        private ContentManager contentManager;
        private Dictionary<string, Song> songs;

        private SongManager()
        {
            songs = new Dictionary<string, Song>();
        }

        public void Initialize(ContentManager content)
        {
            contentManager = content;

            songs.Add("ForestWalk", contentManager.Load<Song>("ForestWalk-320bit"));
            songs.Add("Adventure", contentManager.Load<Song>("Adventure-320bit"));

            PlayLoopingSongs();
        }

        private async void PlayLoopingSongs()
        {
            if (songs.Count == 0)
                return;
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;

            foreach (var song in songs.Values)
            {
                MediaPlayer.Play(song);
                while (MediaPlayer.State != MediaState.Stopped)
                {
                    await Task.Delay(100);
                }
            }
        }
    }
}

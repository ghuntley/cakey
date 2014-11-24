using System;

namespace CakeyApp.Models
{
    public class Playlist
    {
        public Playlist()
        {
            // When a new playlist is created it should be wrapped by
            // default as unwrapping is the responsbiliy of the kid :-)
            IsWrapped = true;
        }

        /// <summary>
        /// True if the playlist has never been opened.
        /// </summary>
        public bool IsWrapped { get; set; }

        /// <summary>
        /// The description of the contents/theme of the playlist.
        /// </summary>
        public string PlaylistDescriptoin { get; set; }

        /// <summary>
        /// The thumbnail to be displayed that represents the playlist.
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// The public youtube link to the videos.
        /// </summary>
        public IObservable<string> Videos { get; set; }
    }
}
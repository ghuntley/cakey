using System;

namespace CakeyApp.Helpers
{
    /// <summary>
    /// This class contains the used keys for Akavache
    /// </summary>
    public static class BlobCacheKeys
    {
        /// <summary>
        /// This is the key prefix for individual playlists. After the hyphen, the GUID of the playlist.
        /// is attached.
        /// </summary>
        public const string Playlist = "playlist-";

        /// <summary>
        /// This is the key for the collection of playlists displayed in the HomeViewcontroller. 
        /// </summary>
        public const string Playlists = "playlists";

        /// <summary>
        /// Contract for Splat to locate the request cache which is typically specified in the application startup for each platform.
        /// </summary>
        public const string RequestCache = "requestCache";

        /// <summary>
        /// This is the key for caching search query responses from YouTube. After the hyphen, the search term.
        /// </summary>
        public const string YoutubePrefix = "youtube-search-";

        public static string GetKeyForPlaylist(Guid playlistId)
        {
            return Playlist + playlistId;
        }

        public static string GetKeyForYoutubeCache(string searchTerm)
        {
            return YoutubePrefix + searchTerm.ToLowerInvariant();
        }
    }
}
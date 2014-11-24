using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeyApp
{
    public static class AppSettings
    {
        /// <summary>
        /// Specifices the Akavache database filename that cached network results are stored in.
        /// </summary>
        public const string RequestCacheFileName = "api-requests.cache.db";

        /// <summary>
        /// The application name used to identify this application when issuing requests to YouTube.
        /// </summary>
        public const string YouTubeApiAppIdentifier = "Cakey";

        /// <summary>
        /// TODO: Apply for own API key; this key belongs to Espera.
        /// The API key to be used when issuing requests to YouTube.
        /// </summary>
        public const string YouTubeApiKey = "AI39si5_zcffmO_ErRSZ9xUkfy_XxPZLWuxTOzI_1RH9HhXDI-GaaQ-j6MONkl2JiF01yBDgBFPbC8-mn6U9Qo4Ek50nKcqH5g";
    }
}

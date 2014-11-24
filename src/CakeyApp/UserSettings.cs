using System;
using Akavache;
using Lager;
using Splat;

namespace CakeyApp
{
    public class UserSettings : SettingsStorage
    {
        public UserSettings(IBlobCache blobCache = null)
            : base("__UserSettings__", blobCache ?? (ModeDetector.InUnitTestRunner() ? new InMemoryBlobCache() : BlobCache.LocalMachine))
        { }


        /// <summary>
        /// Enables or disables automatic anonymous error and data reporting.
        /// </summary>
        public bool EnableAutomaticReports
        {
            get { return this.GetOrCreate(true); }
            set { this.SetOrCreate(value); }
        }

        /// <summary>
        /// The PIN code used to activate parental mode.
        /// </summary>
        public string ParentalModePIN
        {
            get { return this.GetOrCreate(string); }
            set { this.SetOrCreate(value); }
        }

        /// <summary>
        /// Enables or disables streaming videos in the highest quality.
        /// </summary>
        public bool StreamHighestYoutubeQuality
        {
            get { return this.GetOrCreate(true); }
            set { this.SetOrCreate(value); }
        }

        /// <summary>
        /// Set to true after the parent completes the tutorial.
        /// </summary>
        public bool TutorialCompleted
        {
            get { return this.GetOrCreate(false); }
            set { this.SetOrCreate(value); }
        }
    }
}
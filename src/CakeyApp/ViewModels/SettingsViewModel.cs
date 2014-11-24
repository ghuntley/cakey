using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;

namespace CakeyApp.ViewModels
{
    public interface ISettingsViewModel : IRoutableViewModel
    {
        bool EnableAutomaticReports { get; }
        string ParentalModePIN { get; }

        bool StreamHighestYoutubeQuality { get; }
    }

    [DataContract]
    public class SettingsViewModel : BaseViewModel, ISettingsViewModel
    {
        private readonly UserSettings _userSettings;

        public SettingsViewModel(UserSettings userSettings = null, IScreen hostScreen = null)
        {
            _userSettings = userSettings ?? Locator.Current.GetService<UserSettings>();
            this.HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        [IgnoreDataMember]
        public bool EnableAutomaticReports
        {
            get { return _userSettings.EnableAutomaticReports; }
            set { _userSettings.EnableAutomaticReports = value; }
        }

        [IgnoreDataMember]
        public IScreen HostScreen { get; private set; }

        [IgnoreDataMember]
        public string ParentalModePIN
        {
            get { return _userSettings.ParentalModePIN; }
            set { _userSettings.ParentalModePIN = value; }
        }

        [IgnoreDataMember]
        public bool StreamHighestYoutubeQuality
        {
            get { return _userSettings.StreamHighestYoutubeQuality; }
            set { _userSettings.StreamHighestYoutubeQuality = value; }
        }

        [IgnoreDataMember]
        public string UrlPathSegment
        {
            get { return "settings"; }
        }

    }

}

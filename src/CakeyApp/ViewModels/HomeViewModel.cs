using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using CakeyApp.Helpers;
using CakeyApp.Models;
using ReactiveUI;
using Splat;

namespace CakeyApp.ViewModels
{
    public interface IHomeViewModel : IRoutableViewModel
    {
        ReactiveCommand<Unit> DeletePlaylist { get; }

        bool IsParentalMode { get; }
        ReactiveCommand<Unit> NavigateToSettings { get; }

        IObservable<Playlist> Playlists { get; }
        ReactiveCommand<Unit> AddPlaylist(Guid playlistId);
        //ReactiveCommand<bool> RefreshPlaylists();
    }

    [DataContract]
    public class HomeViewModel : BaseViewModel, IHomeViewModel, IEnableLogger
    {

        private readonly ObservableAsPropertyHelper<bool> _isParentalMode;
 
        public HomeViewModel(IScreen hostScreen = null)
        {
            this.HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        public ReactiveCommand<Unit> DeletePlaylist { get; private set; }

        [IgnoreDataMember]
        public IScreen HostScreen { get; private set; }

        /// <summary>
        /// True when the application is in child mode. False when application is in adult mode.
        /// </summary>
        public bool IsParentalMode { get { return _isParentalMode.Value; } }

        public ReactiveCommand<Unit> NavigateToSettings { get; private set; }

        [DataMember]
        public IObservable<Playlist> Playlists { get; private set; }

        [IgnoreDataMember]
        public string UrlPathSegment { get; private set; }

        public ReactiveCommand<Unit> AddPlaylist(Guid playlistId)
        {
            throw new NotImplementedException();
        }
        public void RefreshPlaylists()
        {
            //Playlists = BlobCache.UserAccount.GetObject<Playlist>(BlobCacheKeys.Playlists);

            //return true;
        }

        private void SavePlaylists()
        {
            BlobCache.UserAccount.Invalidate(BlobCacheKeys.Playlists);
            BlobCache.UserAccount.InsertObject(BlobCacheKeys.Playlists, Playlists);
        }
    }
}
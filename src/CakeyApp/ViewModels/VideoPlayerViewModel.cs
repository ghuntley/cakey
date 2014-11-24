using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using CakeyApp.Services;
using ReactiveUI;
using Splat;

namespace CakeyApp.ViewModels
{
    [DataContract]
    public class VideoPlayerViewModel : ReactiveObject, IRoutableViewModel
    {
        public VideoPlayerViewModel(Uri videoUrl, IVideoPlayerService videoPlayerService = null, IScreen hostScreen = null)
        {
            VideoUrl = videoUrl;

            VideoPlayerService = videoPlayerService ?? Locator.Current.GetService<IVideoPlayerService>();
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

            VideoPlayerService.PlayVideo(VideoUrl);

            HostScreen.Router.NavigateBack.Execute(null);
        }

        [IgnoreDataMember]
        public IScreen HostScreen { get; private set; }

        [IgnoreDataMember]
        public string UrlPathSegment
        {
            get { return "VideoPlayer"; }
        }

        [IgnoreDataMember]
        public IVideoPlayerService VideoPlayerService { get; private set; }

        [DataMember]
        public Uri VideoUrl { get; private set; }
    }
}

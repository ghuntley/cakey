using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using ReactiveUI;
using Splat;
using YoutubeExtractor;

namespace CakeyApp.ViewModels
{
    [DataContract]
    public class PlaylistViewModel : ReactiveObject, IRoutableViewModel
    {
        public PlaylistViewModel(IScreen hostScreen = null)
        {
            this.HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

            // Our test youtube link
            string link = "http://r3---sn-ppoxu-ntql.googlevideo.com/videoplayback?ratebypass=yes&expire=1416683715&upn=hlp4CvK2Zyg&fexp=900245,907259,916640,917000,927622,932404,938645,940630,943909,943915,943917,946008,947209,947215,948124,948703,952302,952605,952901,953101,953912,954202,957103,957105,957201,958100&key=yt5&ip=59.167.236.165&id=o-AGTByo-wFF3l6rb7w9Lo_IBELJ2l2A5qiBfYbLFiOJip&initcwndbps=2526250&source=youtube&mv=m&mime=video/mp4&signature=D005B7FCC33B3C9A14B893A70730670453FF68A9.33E2B14840838FF8A5C8016E4B7A152EA4BCFD47&ms=au&ipbits=0&mm=31&mt=1416662073&sver=3&sparams=id,initcwndbps,ip,ipbits,itag,mime,mm,ms,mv,ratebypass,source,upn,expire&itag=22";

            //HostScreen.Router.Navigate.Execute(new VideoPlayerViewModel();

            HostScreen.Router.Navigate.Execute(new VideoPlayerViewModel(new Uri("pNFu3JMV-y4.mp4", UriKind.Relative)));
        }

        [IgnoreDataMember]
        public IScreen HostScreen { get; private set; }

        [IgnoreDataMember]
        public string UrlPathSegment
        {
            get { return "Playlist"; }
        }
    }
}

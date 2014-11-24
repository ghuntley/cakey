using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeyApp.Services;
using Microsoft.Phone.Tasks;

namespace CakeyApp.WindowsPhone.Services
{
    public class VideoPlayer : IVideoPlayerService
    {
        public void PlayVideo(Uri uri)
        {

            //new Uri("pNFu3JMV-y4.mp4", UriKind.Relative)

            MediaPlayerLauncher mediaPlayerLauncher = new MediaPlayerLauncher();


            mediaPlayerLauncher.Media = uri;
            mediaPlayerLauncher.Location = MediaLocationType.Install;
            mediaPlayerLauncher.Controls = MediaPlaybackControls.All;
            mediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;

            mediaPlayerLauncher.Show();

        }
    }
}

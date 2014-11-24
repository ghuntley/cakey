using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeyApp.Services
{
    public interface IVideoPlayerService
    {
        void PlayVideo(Uri uri);
    }
}

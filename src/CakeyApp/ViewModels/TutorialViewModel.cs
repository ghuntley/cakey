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
    public interface ITutorialViewModel : IRoutableViewModel
    {
        ReactiveCommand<bool> NavigateToHome();
    }

    [DataContract]
    public class TutorivalViewModel : ReactiveObject, ITutorialViewModel
    {
        public TutorivalViewModel(IScreen hostScreen = null)
        {
            this.HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

        }

        [IgnoreDataMember]
        public IScreen HostScreen { get; private set; }

        [IgnoreDataMember]
        public string UrlPathSegment { get; private set; }
        public ReactiveCommand<bool> NavigateToHome()
        {
            throw new NotImplementedException();
        }
    }
}
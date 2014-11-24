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
    [DataContract]
    public abstract class BaseViewModel : ReactiveObject, IEnableLogger
    {
        private readonly ObservableAsPropertyHelper<bool> _isUpdating;

        /// <summary>
        /// True when any activity needs to display a visual loading state to a user.
        /// </summary>
        [IgnoreDataMember]
        public bool IsUpdating { get { return _isUpdating.Value; } }
    }
}

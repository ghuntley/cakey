using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeyApp.ViewModels;
using ReactiveUI;
using Xamarin.Forms;

namespace CakeyApp.Views
{
    public partial class VideoPlayerView : ContentPage, IViewFor<VideoPlayerViewModel>
    {
        public VideoPlayerView()
        {
            InitializeComponent();

            //this.OneWayBind(ViewModel, vm => vm.MessageTiles, v => v.MessageTiles.ItemsSource);
        }

        public VideoPlayerViewModel ViewModel
        {
            get { return (VideoPlayerViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly BindableProperty ViewModelProperty =
            BindableProperty.Create<VideoPlayerView, VideoPlayerViewModel>(x => x.ViewModel,
                default(VideoPlayerViewModel), BindingMode.OneWay);

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (VideoPlayerViewModel) value; }
        }
    }
}

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
    public partial class PlaylistView : ContentPage, IViewFor<PlaylistViewModel>
    {
        public PlaylistView()
        {
            InitializeComponent();
        
            //this.OneWayBind(ViewModel, vm => vm.MessageTiles, v => v.MessageTiles.ItemsSource);
        }

        public PlaylistViewModel ViewModel
        {
            get { return (PlaylistViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly BindableProperty ViewModelProperty =
            BindableProperty.Create<PlaylistView, PlaylistViewModel>(x => x.ViewModel, default(PlaylistViewModel), BindingMode.OneWay);

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (PlaylistViewModel)value; }
        }
    }
}

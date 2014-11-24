using System.IO;
using System.Net.Http;
using Akavache;
using Akavache.Sqlite3;
using CakeyApp.Helpers;
using CakeyApp.Services;
using CakeyApp.ViewModels;
using CakeyApp.Views;
using ModernHttpClient;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace CakeyApp
{
    // CoolStuff: This class and anything under it will automatically get
    // saved and restored by ReactiveUI. This is a great place to put all
    // of your startup code - think of it as the "ViewModel for your app".
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        // The Router holds the ViewModels for the back stack. Because it's
        // in this object, it will be serialized automatically.
        public RoutingState Router { get; protected set; }

        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            // Set up Akavache
            // 
            // Akavache is a portable data serialization library that we'll use to
            // cache data that we've downloaded
            BlobCache.ApplicationName = "XamarinEvolveDemo";

            // Set up Fusillade
            //
            // Fusillade is a super cool library that will make it so that whenever
            // we issue web requests, we'll only issue 4 concurrently, and if we
            // end up issuing multiple requests to the same resource, it will
            // de-dupe them. We're saying here, that we want our *backing*
            // HttpMessageHandler to be ModernHttpClient.
            Locator.CurrentMutable.RegisterConstant(new NativeMessageHandler(), typeof(HttpMessageHandler));

            Locator.CurrentMutable.RegisterLazySingleton(() => new VideoService(Locator.Current.GetService<IBlobCache>(BlobCacheKeys.RequestCache)), typeof(IVideoService));

            //Locator.Current.GetService<IBlobCache>(BlobCacheKeys.RequestCacheContract)
            Locator.CurrentMutable.Register(() => new TutorialView(), typeof(IViewFor<ITutorialViewModel>));
            Locator.CurrentMutable.Register(() => new HomeView(), typeof(IViewFor<IHomeViewModel>));
            Locator.CurrentMutable.Register(() => new PlaylistView(), typeof(IViewFor<PlaylistViewModel>));
            Locator.CurrentMutable.Register(() => new VideoPlayerView(), typeof(IViewFor<VideoPlayerViewModel>));

            // Kick off to the first page of our app. If we don't navigate to a
            // page on startup, Xamarin Forms will get real mad (and even if it
            // didn't, our users would!)
            Router.Navigate.Execute(new PlaylistViewModel(this));
        }

        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrapper as an IScreen.
            return new RoutedViewHost();
        }
    }
}

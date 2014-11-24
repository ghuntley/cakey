using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using CakeyApp.Helpers;
using CakeyApp.Models;
using FloJoCore.Helpers;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace CakeyApp.Services
{
    public interface IVideoService
    {
        IObservable<IReadOnlyList<YoutubeVideo>> FetchCachedOrSearch(string searchTerm = null);
        IObservable<IReadOnlyList<YoutubeVideo>> Search(string searchTerm);

    }

    public class VideoService : IVideoService
    {
        /// <summary>
        /// The time a search with a given search term is cached.
        /// </summary>
        public static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(60);

        private readonly IBlobCache _requestCache;
        private readonly YouTubeService _youTubeService;

        public VideoService(IBlobCache requestCache)
        {
            Ensure.ArgumentNotNull(requestCache, "requestCache");

            _requestCache = requestCache;

            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApplicationName = AppSettings.YouTubeApiAppIdentifier,
                ApiKey = AppSettings.YouTubeApiKey,
            });
        }

        public IObservable<IReadOnlyList<YoutubeVideo>> FetchCachedOrSearch(string searchTerm = null)
        {
            searchTerm = searchTerm ?? string.Empty;
            
            return
                Observable.Defer(() => _requestCache.GetOrFetchObject(BlobCacheKeys.GetKeyForYoutubeCache(searchTerm),
                    () => Search(searchTerm), DateTimeOffset.Now + CacheDuration));
        }

        public IObservable<IReadOnlyList<YoutubeVideo>> Search(string searchTerm)
        {
            // TODO: what other options apart from "snippet"?
            var searchQuery = _youTubeService.Search.List("snippet");
            searchQuery.Order = SearchResource.ListRequest.OrderEnum.Rating;
            searchQuery.SafeSearch = SearchResource.ListRequest.SafeSearchEnum.Moderate;
            searchQuery.Q = searchTerm;

            return Observable.FromAsync(async () =>
            {
                var searchResults = await searchQuery.ExecuteAsync();
                return new List<YoutubeVideo>();
            });
            //var service = new YouTubeService
            //service.ApiKey = AppSettings.YoutubeApiKey;

            //var query = new Youtube()(YouTubeQuery.DefaultVideoUri)
            //{
            //    OrderBy = "relevance",
            //    Query = searchTerm,
            //    SafeSearch = YouTubeQuery.SafeSearchValues.None,
            //    NumberToRetrieve = RequestLimit
            //};

            //// NB: I have no idea where this API blocks exactly
            //var settings = new YouTubeRequestSettings("Espera", ApiKey);
            //var request = new YouTubeRequest(settings);
        }
    }
}
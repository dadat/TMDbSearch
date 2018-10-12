using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace GoogleMovies
{
    class SearchClient
    {
        public string mTitle { get; set; }
        public string overview { get; set; }
        public string originalTitle { get; set; }
        public DateTime? releaseDate { get; set; }
        public string originalLanguage { get; set; }
        public string movieTitle_ { get; set; }

        private string apiKey;
        private string searchEngineId;
        private string query;

        public Search getFirstMovie(string movieTitle)
        {
            try
            {
                keys();

                query = movieTitle;

                CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
                Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
                listRequest.Cx = searchEngineId;
                Search search = listRequest.Execute();
                foreach (var item in search.Items)
                {
                    Console.WriteLine("Title : " + item.Title + Environment.NewLine + "Link : " + item.Link + Environment.NewLine + Environment.NewLine);
                }
                Console.ReadLine();

                return search;
            }
            catch (Exception er)
            {
                Console.WriteLine("Error message: " + er.ToString());
                throw;
            }
        }

        public void searchTMDb(string movieTitle)
        {
            movieTitle_ = movieTitle;
            searchUsingTMDb(movieTitle_);
        }

        private void searchUsingTMDb(string movieTitle)
        {
            TMDbClient client = new TMDbClient("");

            SearchContainer<SearchMovie> result = client.SearchMovie(movieTitle);
            var r = result.Results.FirstOrDefault();
            mTitle =  r.Title;
            overview = r.Overview;
            originalTitle = r.OriginalTitle;
            originalLanguage = r.OriginalLanguage;
            releaseDate = r.ReleaseDate;
        }

        private void printItem()
        {
            Console.WriteLine("Items printed");
        }
        
        private void keys()
        {
            apiKey = "";
            searchEngineId = "";
        }

    }

}

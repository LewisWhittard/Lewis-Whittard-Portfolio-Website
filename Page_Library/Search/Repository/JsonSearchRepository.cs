using Page_Library.Search.Entities.SearchResult;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository.Base;
using System.Text.Json;

namespace Page_Library.Search.Repository
{
    public class JsonPageSearchRepository : PageSearchRepositoryBase
    {
        private readonly string _jsonFilePath;

        public JsonPageSearchRepository(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        private List<ISearchResult> LoadData()
        {
            if (!File.Exists(_jsonFilePath))
                return new List<ISearchResult>();

            try
            {
                var json = File.ReadAllText(_jsonFilePath);
                var results = JsonSerializer.Deserialize<List<SearchResult>>(json) ?? new List<SearchResult>();
                return results.Cast<ISearchResult>().ToList();
            }
            catch (JsonException ex)
            {
                throw new Exception($"Failed to deserialize JSON from {_jsonFilePath}", ex);
            }
            catch (IOException ex)
            {
                throw new Exception($"Failed to read file {_jsonFilePath}", ex);
            }
        }

        public override List<ISearchResult> Search()
        {
            try
            {
                var results = LoadData() ?? new List<ISearchResult>();
                return results.Any() ? results : new List<ISearchResult>();
            }
            catch (Exception ex)
            {
                throw new Exception("Search operation failed.", ex);
            }
        }

        public override List<ISearchResult> Search(
            int id,
            bool programming,
            bool testing,
            bool games,
            bool threeDAssets,
            bool twoDAssets,
            bool blog)
        {
            try
            {
                var results = LoadData() ?? new List<ISearchResult>();

                // Filter by ID first
                var filteredResults = results.Where(r => r.ID == id).ToList();

                // Apply category filters
                var categoryFilters = new Dictionary<string, bool>
                {
                    { "Programming", programming },
                    { "Testing", testing },
                    { "Games", games },
                    { "ThreeDAssets", threeDAssets },
                    { "TwoDAssets", twoDAssets },
                    { "Blog", blog }
                };

                foreach (var category in categoryFilters.Where(kvp => !kvp.Value).Select(kvp => kvp.Key))
                {
                    filteredResults.RemoveAll(x => x.Category.Contains(category));
                }

                return filteredResults.Any() ? filteredResults : new List<ISearchResult>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Search by ID ({id}) with category filters failed.", ex);
            }
        }


    }
}


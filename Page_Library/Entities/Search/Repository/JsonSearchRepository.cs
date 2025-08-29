using Page_Library.Entities.Search.Entities.SearchResult;
using Page_Library.Entities.Search.Entities.SearchResult.Interface;
using Page_Library.Entities.Search.Repository.Base;
using System.Text.Json;

namespace Page_Library.Entities.Search.Repository
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

        public override List<ISearchResult> Search(int id)
        {
            try
            {
                var results = LoadData() ?? new List<ISearchResult>();
                var filteredResults = results.Where(r => r.ID == id).ToList();
                return filteredResults.Any() ? filteredResults : new List<ISearchResult>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Search by ID ({id}) failed.", ex);
            }
        }
    }
}


using Page_Library.Content.Entities.Content.DTO;
using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Base;
using Page_Library.Search.Entities.SearchResult.Interface;
using Page_Library.Search.Repository;
using Page_Library.Search.Repository.Interface;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Page_Library.Page.Repository
{
    public class JsonPageRepository : PageRepositoryBase
    {
        private readonly string _pageRepositoryPath;

        public JsonPageRepository(string pageRepositoryPath) : base(pageRepositoryPath)
        {
            _pageRepositoryPath = pageRepositoryPath;
        }

        public override IPage GetPage(int Id)
        {
            try
            {
                var result = LoadData().Where(x => x.ExternalId == Id);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Failed to load data: ExternalId lookup encountered an error.");
            }



        }

        private List<IPage> LoadData()
        {
            if (!File.Exists(_pageRepositoryPath))
                return new List<IPage>();

            try
            {
                var json = File.ReadAllText(_pageRepositoryPath);
                var results = JsonSerializer.Deserialize<List<contentDTO>>(json) ?? new List<contentDTO>();

                List<IPage> toReturn = new List<IPage>();

                foreach (var item in results)
                {
                    toReturn.Add(new Entities.Page.Page(item));
                }

                return toReturn;
            }
            catch (JsonException ex)
            {
                throw new Exception($"Failed to deserialize JSON from {_pageRepositoryPath}", ex);
            }
            catch (IOException ex)
            {
                throw new Exception($"Failed to read file {_pageRepositoryPath}", ex);
            }
        }
    }
}

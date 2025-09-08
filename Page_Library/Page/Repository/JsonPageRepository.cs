using Page_Library.Content.Entities.Content.DTO;
using Page_Library.Page.Entities.Page.DTO;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Base;
using System.Text.Json;

namespace Page_Library.Page.Repository
{
    public class JsonPageRepository : PageRepositoryBase
    {
        private readonly string _pageRepositoryPath;

        public JsonPageRepository(string pageRepositoryPath)
        {
            _pageRepositoryPath = pageRepositoryPath;
        }

        public override IPage GetPage(int Id)
        {
            try
            {
                var result = LoadData().Where(x => x.ExternalId == Id);
                return (IPage)result;
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
                var results = JsonSerializer.Deserialize<List<PageDTO>>(json) ?? new List<PageDTO>();

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

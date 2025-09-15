using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Base;
using System.Text.Json;
using Page_Library.Content.Entities.Content.DTO;

namespace Page_Library.Content.Repository
{
    public class JsonContentRepository :ContentRepositoryBase
    {

        private readonly string _jsonFilePath;

        public JsonContentRepository(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        private List<IContent> LoadData()
        {
            if (!File.Exists(_jsonFilePath))
                return new List<IContent>();

            try
            {
                var json = File.ReadAllText(_jsonFilePath);
                var results = JsonSerializer.Deserialize<List<contentDTO>>(json) ?? new List<contentDTO>();

                List<IContent> toReturn = new List<IContent>();

                foreach (var item in results)
                {
                    toReturn.Add(new Entities.Content.Image(item));
                }

                return toReturn;
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

        public override IContent GetContent(int id)
        {
            return LoadData().FirstOrDefault(x => x.ID == id);
        }
    }
}

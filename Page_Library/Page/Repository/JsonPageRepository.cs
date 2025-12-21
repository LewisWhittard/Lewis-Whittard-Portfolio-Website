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

        public override IPage GetPage(string Id)
        {
            try
            {
                var result = LoadData().Where(x => x.ExternalId == Id).FirstOrDefault();
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Failed to load data: ExternalId lookup encountered an error.");
            }



        }

        public override List<IPage> GetPages(string? searchTerm, string category)
        {
            try
            {
                var data = LoadData();
                if (string.IsNullOrEmpty(searchTerm) && string.IsNullOrEmpty(category) || category.ToLower() == "all" && string.IsNullOrEmpty(searchTerm))
                {
                    return data.Where(r => r.PageType == "Content Cluster Page").ToList(); 
                }
                else if (string.IsNullOrEmpty(searchTerm))
                {
                    var result = data.Where(r => r.Category.ToLower().Contains(category.ToLower())).ToList().Where(r => r.PageType == "Content Cluster Page").ToList();
                    return result;
                }
                else if (category == "All")
                {
                    var result = data.Where(r =>
                    r.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    r.Title.ToLower() == searchTerm.ToLower() ||
                    r.Meta.MetaTitle.ToLower().Contains(searchTerm.ToLower()) ||
                    r.Meta.MetaTitle.ToLower() == searchTerm.ToLower() ||
                    r.Meta.MetaDescription.ToLower().Contains(searchTerm.ToLower()) ||
                    r.Meta.MetaDescription.ToLower() == searchTerm.ToLower()
                    ).Where(r => r.PageType == "Content Cluster Page").ToList();

                    return result;
                }
                else
                {
                    var result = data.Where(r =>
                    r.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    r.Title.ToLower() == searchTerm.ToLower() ||
                    r.Meta.MetaTitle.ToLower().Contains(searchTerm.ToLower()) ||
                    r.Meta.MetaTitle.ToLower() == searchTerm.ToLower() ||
                    r.Meta.MetaDescription.ToLower().Contains(searchTerm.ToLower()) ||
                    r.Meta.MetaDescription.ToLower() == searchTerm.ToLower()
                    ).Where(r => r.Category.ToLower().Contains(category.ToLower())).Where(r => r.PageType == "Content Cluster Page").ToList();

                    return result;
                }



            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching pages", ex);
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

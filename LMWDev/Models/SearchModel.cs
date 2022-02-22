using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using LMWDev.SpreadsheetConnection;

namespace LMWDev.Models
{
	public class SearchModel
	{
		public string Search { get; set; }
		public bool GamesCategory { get; set; }
		public bool ProgrammingCategory { get; set; }
		public bool TestingCategory { get; set; }
		public bool ThreeDAssetsCategory {get;set;}
		public bool TwoDAssetCategory { get; set; }
		public bool BlogCategory { get; set; }
		public List<SingleSearchResultCompleted> ListOfSingleSearchResults { get; set; }
		public bool FlexibleMeta { get; set; }
	}

	public class SearchResultFunctions
	{
		public List<SearchRowResultsSingle> FilterOnTitleAndDescription(List<SearchRowResultsSingle> ListOfResults, string search)
		{
			List<SearchRowResultsSingle> Filtered = new List<SearchRowResultsSingle>();

			foreach (var item in ListOfResults)
			{
				if (item.title.ToLower().Contains(search.ToLower()) || item.description.ToLower().Contains(search.ToLower()))
				{
					Filtered.Add(item);
				}
			}
			
			return Filtered;
		}

		public List<SearchRowResultsSingle> FilterOnDescription(List<SearchRowResultsSingle> Description)
		{
			return null;
		}

		public List<SearchRowResultsSingle> FilterOnCategory(List<SearchRowResultsSingle> ListOfResults, bool Programming, bool Testing, bool Games, bool ThreeDAssets, bool TwoDAssets, bool Blog)
		{
			if (Programming == false)
			{
				ListOfResults.RemoveAll(x => x.category.Contains("Programming"));
			}
			if (Testing == false)
			{
				ListOfResults.RemoveAll(x => x.category.Contains("Testing"));
			}

			if (Games == false)
			{
				ListOfResults.RemoveAll(x => x.category.Contains("Games"));
			}

			if (ThreeDAssets == false)
			{
				ListOfResults.RemoveAll(x => x.category.Contains("ThreeDAssets"));
			}

			if (TwoDAssets == false)
			{
				ListOfResults.RemoveAll(x => x.category.Contains("TwoDAssets"));
			}

			if (Blog == false)
			{
				ListOfResults.RemoveAll(x => x.category.Contains("Blog"));
			}

			return ListOfResults;
		}

		public List<ImagesTableSingle> FilterOnCoverImage(List<ImagesTableSingle> ListOfResults)
		{
			ListOfResults.RemoveAll(x => x.isCoverImage.ToLower().Contains("false"));
			

			return ListOfResults;
		}

		public List<SingleSearchResultCompleted> AddCoverImageAndButtonIdToResults(List<ImagesTableSingle> Images, List<SearchRowResultsSingle> Results)
		{
			List<SingleSearchResultCompleted> ResultsWithImage = new List<SingleSearchResultCompleted>();
			
			foreach (var item in Results)
			{
				SingleSearchResultCompleted SingleRow = new SingleSearchResultCompleted();

				SingleRow.ID = item.iD;
				SingleRow.Description = item.description;
				SingleRow.Category = item.category;
				SingleRow.Title = item.title;
				SingleRow.ImageId = item.imageID;
				SingleRow.CoverImage = GetImage(item.imageID, Images);
				string IDNumberAsAString = SingleRow.ID.ToString();
				SingleRow.ButtonID = IDNumberAsAString + "Button";
				ResultsWithImage.Add(SingleRow);


			}




			return ResultsWithImage;
		}

		public ImagesTableSingle GetImage(long ImageId, List<ImagesTableSingle> ImageList)
		{
			var ImageToReturn = ImageList.Find(x => x.iD == ImageId);


			return ImageToReturn;
		}
	}
	

	public class SingleSearchResult
	{
		public long ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public long ImageId { get; set; }
		public string Category { get; set; }
	}

	public class SingleSearchResultCompleted : SingleSearchResult
	{
		public string ButtonID { get; set; }
		public ImagesTableSingle CoverImage { get; set; }
	}

	public class Image
	{
		long ID { get; set; }
		string Name { get; set; }
		string Path { get; set; }
		string IsCoverImage { get; set; }
		string Tags { get; set; }
		string Alt { get; set; }
	}


	
}

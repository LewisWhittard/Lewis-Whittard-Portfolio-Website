using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMWDev.Models;
using LMWDev.SpreadsheetConnection;

namespace LMWDev.Controllers
{
	public class SearchController : Controller
	{
		private readonly SearchService _searchService;

		public IActionResult Index()
		{
			SearchModel SearchModel = new SearchModel();
			SpreadsheetConnectionClass Spreadsheet = new SpreadsheetConnectionClass();

			var UnfilteredResults  = Spreadsheet.SearchRowResults.ToList();
			var UnfilteredImages = Spreadsheet.ImagesTable.ToList();

			
			SearchModel.Search = null;
			SearchModel.BlogCategory = true;
			SearchModel.GamesCategory = true;
			SearchModel.ProgrammingCategory = true;
			SearchModel.ThreeDAssetsCategory = true;
			SearchModel.TwoDAssetCategory = true;
			SearchModel.TestingCategory = true;
			SearchModel.FlexibleMeta = false;

			SearchResultFunctions SearchResultFunctionsClass = new SearchResultFunctions();

			var FilteredByCategory = SearchResultFunctionsClass.FilterOnCategory(UnfilteredResults, SearchModel.ProgrammingCategory, SearchModel.TestingCategory, SearchModel.GamesCategory,SearchModel.ThreeDAssetsCategory, SearchModel.TwoDAssetCategory, SearchModel.BlogCategory);

			List<SearchRowResultsSingle> FilteredByTitleAndDescription = new List<SearchRowResultsSingle>();


		
				FilteredByTitleAndDescription = FilteredByCategory.ToList();
			
			var CoverImageFiltered = SearchResultFunctionsClass.FilterOnCoverImage(UnfilteredImages);

			var FinalResults = SearchResultFunctionsClass.AddCoverImageAndButtonIdToResults(CoverImageFiltered, FilteredByTitleAndDescription);

			FinalResults.Reverse();
			
			SearchModel.ListOfSingleSearchResults = FinalResults;

			return View(SearchModel);
		}

		public IActionResult Modified(string Search, bool Blog, bool Games, bool Programming, bool ThreeD, bool TwoD, bool Testing)
		{
			SearchModel SearchModel = new SearchModel();
			SpreadsheetConnectionClass Spreadsheet = new SpreadsheetConnectionClass();

			var UnfilteredResults = Spreadsheet.SearchRowResults.ToList();
			var UnfilteredImages = Spreadsheet.ImagesTable.ToList();


			SearchModel.Search = Search;
			SearchModel.BlogCategory = Blog;
			SearchModel.GamesCategory = Games;
			SearchModel.ProgrammingCategory = Programming;
			SearchModel.ThreeDAssetsCategory = ThreeD;
			SearchModel.TwoDAssetCategory = TwoD;
			SearchModel.TestingCategory = Testing;
			SearchModel.FlexibleMeta = false;

			SearchResultFunctions SearchResultFunctionsClass = new SearchResultFunctions();

			var FilteredByCategory = SearchResultFunctionsClass.FilterOnCategory(UnfilteredResults, Programming, Testing, Games, ThreeD, TwoD, Blog);

			List<SearchRowResultsSingle> FilteredByTitleAndDescription = new List<SearchRowResultsSingle>();


			if (Search != null)
			{
				FilteredByTitleAndDescription = SearchResultFunctionsClass.FilterOnTitleAndDescription(FilteredByCategory, Search);
			}

			else
			{
				FilteredByTitleAndDescription = FilteredByCategory.ToList();
			}

			var CoverImageFiltered = SearchResultFunctionsClass.FilterOnCoverImage(UnfilteredImages);

			var FinalResults = SearchResultFunctionsClass.AddCoverImageAndButtonIdToResults(CoverImageFiltered, FilteredByTitleAndDescription);

			FinalResults.Reverse();

			SearchModel.ListOfSingleSearchResults = FinalResults;

			return View(SearchModel);
		}
	}
}

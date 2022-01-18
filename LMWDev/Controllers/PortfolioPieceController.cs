using LMWDev.SpreadsheetConnection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMWDev.Models; 

namespace LMWDev.Controllers
{
	public class PortfolioPieceController : Controller
	{
		public IActionResult Index(long Id)
		{
			SpreadsheetConnectionClass Spreadsheet = new SpreadsheetConnectionClass();
			PortfolioPiecePageFunctions Functions = new PortfolioPiecePageFunctions();
			var Body = Functions.ConstructBody(Id, Spreadsheet.BodyTable);
			var Meta = Functions.ConstructMeta(Id, Spreadsheet.MetaTable);
			var UnfilteredContent = Spreadsheet.ImagesTable.ToList();
			var CombinedBody = Functions.CombineBodyWithContent(Id,Body,UnfilteredContent);
			PortfolioPieceModel ViewModel = new PortfolioPieceModel();
			ViewModel.Body = CombinedBody;
			ViewModel.Meta = Meta;
			ViewModel.FlexibleMeta = true;
			return View(ViewModel);
		}
	}
}

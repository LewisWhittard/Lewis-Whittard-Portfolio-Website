using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace LMWDev.SpreadsheetConnection
{
	public class SpreadsheetConnectionClass
	{
		public List<SearchRowResultsSingle> SearchRowResults = new List<SearchRowResultsSingle>();
		public List<ImagesTableSingle> ImagesTable = new List<ImagesTableSingle>();
		public List<BodyTableSingle> BodyTable = new List<BodyTableSingle>();
		public List<MetaTableSingle> MetaTable = new List<MetaTableSingle>();


		public SpreadsheetConnectionClass()
		{
			string path = @"./SpreadSheet/PortfolioSiteDB.xlsx";
			var workbook = new XLWorkbook(path);

			ConstructSearchResults(workbook);
			ConstructImageTableResults(workbook);
			ConstructBodyTableResults(workbook);
			ConstructMetaTableResults(workbook);
		}

		public void ConstructSearchResults(IXLWorkbook Workbook)
		{

			var SearchRowResultsWS = Workbook.Worksheet(1);
			int RowCount = 0;

			RowCount = 2;
			bool unlock = false;

			do
			{


				SearchRowResultsSingle SingleRow = new SearchRowResultsSingle();
				var Row = SearchRowResultsWS.Row(RowCount);
				


				if (Row.Cell(1).Value.ToString() == "")
				{
					unlock = true;
					break;
				}

				var IdCell = Row.Cell(1).Value.ToString();
				long IdCellong = Int64.Parse(IdCell);
				var titleCell = Row.Cell(2).Value.ToString();
				var descriptionCell = Row.Cell(3).Value.ToString();
				var imageIdCell = Row.Cell(4).Value.ToString();
				long imageIdCellLong = Int64.Parse(imageIdCell);
				var categoryCell = Row.Cell(5).Value.ToString();

				SingleRow.iD = IdCellong;
				SingleRow.title = titleCell;
				SingleRow.description = descriptionCell;
				SingleRow.imageID = imageIdCellLong;
				SingleRow.category = categoryCell;

				SearchRowResults.Add(SingleRow);

				RowCount++;

			} while (unlock == false);

		}

		public void ConstructImageTableResults(IXLWorkbook Workbook)
		{

			var ImageTableWS = Workbook.Worksheet(2);
			int RowCount = 0;

			RowCount = 2;
			bool unlock = false;

			do
			{


				ImagesTableSingle SingleRow = new ImagesTableSingle();
				var Row = ImageTableWS.Row(RowCount);



				if (Row.Cell(1).Value.ToString() == "")
				{
					unlock = true;
					break;
				}

				var IdCell = Row.Cell(1).Value.ToString();
				long IdCellLong = Int64.Parse(IdCell);
				var nameCell = Row.Cell(2).Value.ToString();
				var PathCell = Row.Cell(3).Value.ToString();
				var IsCoverImageCell = Row.Cell(4).Value.ToString();
				var AltCell = Row.Cell(5).Value.ToString();

				SingleRow.iD = IdCellLong;
				SingleRow.name = nameCell;
				SingleRow.path = PathCell;
				SingleRow.isCoverImage = IsCoverImageCell;
				SingleRow.alt = AltCell;

				ImagesTable.Add(SingleRow);

				RowCount++;

			} while (unlock == false);

		}

		public void ConstructBodyTableResults(IXLWorkbook Workbook)
		{

			var ImageTableWS = Workbook.Worksheet(3);
			int RowCount = 0;

			RowCount = 2;
			bool unlock = false;

			do
			{


				BodyTableSingle SingleRow = new BodyTableSingle();
				var Row = ImageTableWS.Row(RowCount);



				if (Row.Cell(1).Value.ToString() == "")
				{
					unlock = true;
					break;
				}

				var IdCell = Row.Cell(1).Value.ToString();
				long IdCellLong = Int64.Parse(IdCell);
				var SearchResultIdCell = Row.Cell(2).Value.ToString();
				long SearchResultIdLong = Int64.Parse(SearchResultIdCell);
				var TypeCell = Row.Cell(3).Value.ToString();
				var ContentCell = Row.Cell(4).Value.ToString();

				SingleRow.iD = IdCellLong;
				SingleRow.searchResultId = SearchResultIdLong;
				SingleRow.Type = TypeCell;
				SingleRow.Content = ContentCell;

				BodyTable.Add(SingleRow);

				RowCount++;

			} while (unlock == false);

		}

		public void ConstructMetaTableResults(IXLWorkbook Workbook)
		{

			var ImageTableWS = Workbook.Worksheet(4);
			int RowCount = 0;

			RowCount = 2;
			bool unlock = false;

			do
			{


				MetaTableSingle SingleRow = new MetaTableSingle();
				var Row = ImageTableWS.Row(RowCount);



				if (Row.Cell(1).Value.ToString() == "")
				{
					unlock = true;
					break;
				}

				var IdCell = Row.Cell(1).Value.ToString();
				long IdCellLong = Int64.Parse(IdCell);
				var SearchResultIdCell = Row.Cell(2).Value.ToString();
				long SearchResultIdLong = Int64.Parse(SearchResultIdCell);
				var nameCell = Row.Cell(3).Value.ToString();
				var ContentCell = Row.Cell(4).Value.ToString();

				SingleRow.iD = IdCellLong;
				SingleRow.searchResultId = SearchResultIdLong;
				SingleRow.name = nameCell;
				SingleRow.content = ContentCell;
				

				MetaTable.Add(SingleRow);

				RowCount++;

			} while (unlock == false);

		}
	}
}


		public class SearchRowResultsSingle
		{
			public long iD { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public long imageID { get; set; }
			public string category { get; set; }

		}
		
		public class ImagesTableSingle
		{
			public long iD { get; set; }
			public string name { get; set; }
			public string path { get; set; }
			public string isCoverImage { get; set; }
			public string alt { get; set; }
		}

		public class BodyTableSingle
		{
			public long iD {get; set;}
			public long searchResultId { get; set; }
			public string Type { get; set; }
			public string Content { get; set; }
		}

		public class MetaTableSingle
		{
			public long iD { get; set; }
			public long searchResultId { get;set;}
			public string name { get; set; }
			public string content { get; set; }

		}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMWDev.Models
{
	public class PortfolioPieceModel
	{
		public List<MetaTableSingle> Meta { get; set; }
	
		public List<PortfolioPieceCombinedWithMedia> Body { get; set; }

		public bool FlexibleMeta { get; set; }
	}

	public class PortfolioPieceCombinedWithMedia : BodyTableSingle
	{
		public ImagesTableSingle BodyContent {get;set;}
	}



	public class PortfolioPiecePageFunctions
{

		public List<BodyTableSingle> ConstructBody(long iD,List<BodyTableSingle> allContent)
		{
			allContent.RemoveAll(x => x.searchResultId != iD);

			return allContent;
		}

		public List<MetaTableSingle> ConstructMeta(long iD, List<MetaTableSingle> AllMeta)
		{
			AllMeta.RemoveAll(x => x.searchResultId != iD);

			return AllMeta;
		}

		public List<ImagesTableSingle> FilterContent(long iD, List<ImagesTableSingle> allContent)
		{
			allContent.RemoveAll(x => x.iD != iD);

			return allContent;
		}

		public List<PortfolioPieceCombinedWithMedia> CombineBodyWithContent(long iD,List<BodyTableSingle> Body , List<ImagesTableSingle> Content )
		{
			List<PortfolioPieceCombinedWithMedia> List = new List<PortfolioPieceCombinedWithMedia>();
			
			foreach (var item in Body)
			{
				PortfolioPieceCombinedWithMedia SingleRow = new PortfolioPieceCombinedWithMedia();

				SingleRow.iD = item.iD;
				SingleRow.Type = item.Type;
				SingleRow.Content = item.Content;
				SingleRow.searchResultId = item.searchResultId;
				
				if (item.Type == "Image-Center" || item.Type == "Video" || item.Type == "DownloadFile")
				{
					SingleRow.BodyContent = GetContent(Convert.ToInt64(item.Content),Content);
				}

				List.Add(SingleRow);
			}

			return List;
		
		}

		public ImagesTableSingle GetContent(long Id, List<ImagesTableSingle> Content)
		{

			var ToReturn = Content.First(x => x.iD.Equals(Id));

			return ToReturn;
		}

		
	}
}

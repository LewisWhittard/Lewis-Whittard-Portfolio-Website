using Infrastructure.Models.Data.InfomationBlock.Interfaces;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class Paragraph : IParagraph,IData
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int InfomationBlockid { get; set; }

        public Paragraph(string text,int DisplayOrder,int id, bool deleted,bool inactive,int infomationBlockId)
        {
            Text = text;
            DisplayOrder = 0;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            InfomationBlockid = infomationBlockId;
        }

        public Paragraph()
        {
            
        }
    }
}

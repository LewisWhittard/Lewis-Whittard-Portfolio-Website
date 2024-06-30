using Infrastructure.Models.Data.Table.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Table
{
    public class Table : IData, ITable
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public List<Header>? Headers { get; private set; }
        public List<List<Column>>? Columns { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string UIId { get; private set; }
        public int PageId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Table()
        {
            UIConcreteType = UIConcrete.Table;
        }

        public Table(int id, bool deleted, bool inactive, int displayOrder, List<Header>? headers, List<List<Column>>? columns, string uIId, string title, int pageId)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Headers = headers;
            Columns = columns;
            UIConcreteType = UIConcrete.Table;
            DisplayOrder = displayOrder;
            UIId = uIId;
            Title = title;
            PageId = pageId;
        }
    }
}

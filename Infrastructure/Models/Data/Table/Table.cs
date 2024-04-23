using Infrastructure.Models.Data.Table.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Table
{
    public class Table : IData, ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Header>? Headers { get; set; }
        public List<List<Column>>? Columns { get; set; }
        public int? DisplayOrder { get; set; }
        public string GUID { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Table()
        {
            
        }

        public Table(int id, bool deleted, bool inactive, int displayOrder, List<Header>? headers, List<List<Column>>? columns, string webpage, string gUID, string title)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Headers = headers;
            Columns = columns;
            UIConcreteType = UIConcrete.Table;
            GUID = gUID;
            Title = title;
        }
    }
}

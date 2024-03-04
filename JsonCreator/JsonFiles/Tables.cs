using Infrastructure.Models.Data.Table.Column;
using Infrastructure.Models.Data.Table.Header;
using Infrastructure.Models.Data.Table;
using Newtonsoft.Json;
using Infrastructure.Repository.Json.Table.Container;

namespace JsonCreator.Pages
{
    public class Tables
    {
        private readonly Container Container;

        public Tables()
        {
            var Home = Homepage();
            Container = new Container(Home);
            var json = JsonConvert.SerializeObject(Container,Formatting.Indented);
        }

        public List<Table> Homepage()
        {
            Header Qualification = new Header(0, false, false, 0, 0, "Qualification");
            Header Result = new Header(1, false, false, 1, 0, "Result");
            Header Year = new Header(2, false, false, 2, 0, "Year");
            Header EducationalEstablishment = new Header(3, false, false, 3, 0, "Educational Establishment");
            Column Qualification0 = new Column(0, false, false, "SoftwareDevelopmentTechnicianLevel3", 0, 0, 0);
            Column Grade0 = new Column(1, false, false, "Pass", 1, 0, 0);
            Column Date0 = new Column(2, false, false, "2018-2020", 2, 0, 0);
            Column EducationalEstablishment0 = new Column(3, false, false, "QA Apprenticeships", 3, 0, 0);
            Column Qualification1 = new Column(4, false, false, "BTEC Level 3 Extended Diploma in Creative Media Production (Game Development) (QCF)", 0, 1, 0);
            Column Grade1 = new Column(5, false, false, "Pass", 1, 1, 0);
            Column Date1 = new Column(6, false, false, "2018-2020", 2, 1, 0);
            Column EducationalEstablishment1 = new Column(7, false, false, "Wakefield College", 3, 1, 0);
            List<Header> Headers = new List<Header>();
            Headers.Add(Qualification);
            Headers.Add(Result);
            Headers.Add(Year);
            Headers.Add(EducationalEstablishment);
            List<Column> Columns = new List<Column>();
            Columns.Add(Qualification0);
            Columns.Add(Grade0);
            Columns.Add(Date0);
            Columns.Add(EducationalEstablishment0);
            Columns.Add(Qualification1);
            Columns.Add(Grade1);
            Columns.Add(Date1);
            Columns.Add(EducationalEstablishment1);
            Table Qualifications = new Table(0, false, false, 0, Headers, Columns,"Homepage");
            List<Table> Tables = new List<Table>();
            Tables.Add(Qualifications);

            return Tables;
        }
    }
}

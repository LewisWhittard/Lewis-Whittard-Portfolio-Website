using Infrastructure.Models.Data.Table;
using Newtonsoft.Json;

namespace JsonCreator.Pages
{
    public class Tables
    {
        private readonly Infrastructure.Repository.Json.Table.Container.Table Container;

        public Tables()
        {
            var Home = Homepage();
            Container = new Infrastructure.Repository.Json.Table.Container.Table(Home);
            var json = JsonConvert.SerializeObject(Container);
        }

        public List<Infrastructure.Models.Data.Table.Table> Homepage()
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
            List<Header> QualificationsHeaders = new List<Header>();
            QualificationsHeaders.Add(Qualification);
            QualificationsHeaders.Add(Result);
            QualificationsHeaders.Add(Year);
            QualificationsHeaders.Add(EducationalEstablishment);
            List<Column> QualificationsColumns = new List<Column>();
            QualificationsColumns.Add(Qualification0);
            QualificationsColumns.Add(Grade0);
            QualificationsColumns.Add(Date0);
            QualificationsColumns.Add(EducationalEstablishment0);
            QualificationsColumns.Add(Qualification1);
            QualificationsColumns.Add(Grade1);
            QualificationsColumns.Add(Date1);
            QualificationsColumns.Add(EducationalEstablishment1);

            Header JobTitle = new Header(5, false, false, 0, 1, "Job Title");
            Header Span = new Header(6, false, false, 1, 1, "Span");
            Column JobTitle0 = new Column(8, false, false, "Aprentice Software Tester", 0, 4, 1);
            Column DateSpan0 = new Column(9, false, false, "0000-0000", 1, 4, 1);
            Column JobTitle1 = new Column(10, false, false, "Junior Software Developer", 0, 3, 1);
            Column DateSpan1 = new Column(11, false, false, "0000-0000", 1, 3, 1);
            Column JobTitle2 = new Column(12, false, false, "Junior Software Developer", 0, 2, 1);
            Column DateSpan2 = new Column(13, false, false, "0000-0000", 1, 2, 1);
            Column JobTitle3 = new Column(14, false, false, "Support Consultant (2nd Line Support Analyst)", 0, 0, 1);
            Column DateSpan3 = new Column(15, false, false, "0000-0000", 1, 0, 1);
            List<Header> WorkHistoryHeaders = new List<Header>();
            List<Column> WorkHistoryColumns = new List<Column>();
            WorkHistoryHeaders.Add(JobTitle);
            WorkHistoryHeaders.Add(Span);
            WorkHistoryColumns.Add(JobTitle0);
            WorkHistoryColumns.Add(DateSpan0);
            WorkHistoryColumns.Add(JobTitle1);
            WorkHistoryColumns.Add(DateSpan1);
            WorkHistoryColumns.Add(JobTitle2);
            WorkHistoryColumns.Add(DateSpan2);
            WorkHistoryColumns.Add(JobTitle3);
            WorkHistoryColumns.Add(DateSpan3);

            Infrastructure.Models.Data.Table.Table Qualifications = new Infrastructure.Models.Data.Table.Table(0, false, false, 0, QualificationsHeaders, QualificationsColumns,"Homepage");
            Infrastructure.Models.Data.Table.Table WorkHistory = new Infrastructure.Models.Data.Table.Table(0, false, false, 0, WorkHistoryHeaders, WorkHistoryColumns, "Homepage");
            List<Infrastructure.Models.Data.Table.Table> Tables = new List<Infrastructure.Models.Data.Table.Table>();
            Tables.Add(Qualifications);
            Tables.Add(WorkHistory);
            return Tables;
        }
    }
}

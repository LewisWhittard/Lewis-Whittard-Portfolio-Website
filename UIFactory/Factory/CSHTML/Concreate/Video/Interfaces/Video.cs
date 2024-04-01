namespace UIFactory.Factory.CSHTML.Concreate.Video.Interfaces
{
    public interface IVideo
    {
        public string Source { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int DisplayOrder { get; set; }
    }
}

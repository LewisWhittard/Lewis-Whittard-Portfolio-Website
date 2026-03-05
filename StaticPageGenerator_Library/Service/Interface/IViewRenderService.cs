namespace StaticPageGenerator_Library.Service.Interface
{
    public interface IViewRenderService
    {
        public abstract Task<string> RenderToStringAsync(string viewName, object model);
    }
}
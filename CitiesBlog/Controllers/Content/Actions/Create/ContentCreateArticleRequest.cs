namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public record ContentCreateArticleRequest : ContentCreateRequestBase
    {
        public string Text { get; set; }
    }
}
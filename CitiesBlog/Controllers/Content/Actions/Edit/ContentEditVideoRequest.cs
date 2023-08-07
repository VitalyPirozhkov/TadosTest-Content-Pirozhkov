namespace CitiesBlog.Controllers.Content.Actions.Edit
{
    public record ContentEditVideoRequest : ContentEditRequestBase
    {
        public string Url { get; set; }
    }
}
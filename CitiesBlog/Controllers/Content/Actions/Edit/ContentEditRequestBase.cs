namespace CitiesBlog.Controllers.Content.Actions.Edit
{
    public abstract record ContentEditRequestBase
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
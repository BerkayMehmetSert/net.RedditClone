namespace Application.Contracts.Constants.Post;

public static class PostValidationMessages
{
    public const string NameRequired = "Name is required";
    public const string NameLength = "Name must be between 3 and 50 characters";
    public const string DescriptionRequired = "Description is required";
    public const string DescriptionLength = "Description must be between 3 and 500 characters";
    public const string UrlRequired = "Url is required";
    public const string UrlLength = "Url must be between 3 and 120 characters";
    public const string SubredditIdRequired = "SubredditId is required";
}
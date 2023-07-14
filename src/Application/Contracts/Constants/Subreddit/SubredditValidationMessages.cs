namespace Application.Contracts.Constants.Subreddit;

public static class SubredditValidationMessages
{
    public const string NameRequired = "Name is required";
    public const string NameLength = "Name must be between 3 and 50 characters";
    public const string DescriptionRequired = "Description is required";
    public const string DescriptionLength = "Description must be between 3 and 500 characters";
}
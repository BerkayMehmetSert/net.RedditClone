using Application.Contracts.Requests.Post;
using Application.Contracts.Responses;
using Domain.Entities;

namespace Application.Contracts.Services;

public interface IPostService
{
    void CreatePost(CreatePostRequest request);
    void UpdatePostVoteCount(Guid postId, int voteCount);
    PostResponse GetPostById(Guid id);
    List<PostResponse> GetAllPosts();
    List<PostResponse> GetAllPostsByUsername(string username);
    List<PostResponse> GetAllPostsBySubredditId(Guid subredditId);
    Post GetPostEntityById(Guid id);
}
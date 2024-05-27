using Microsoft.AspNetCore.Http;
using ReviewProvider.Models;

namespace ReviewProvider.Services
{
    public interface ICreateUserReviewService
    {
        Task<bool> SaveUserReviewRequest(UserReviewRequest userReviewRequest);
        Task<UserReviewRequest> UnpackUserReviewRequest(HttpRequest req);
        Task<bool> UserExists(string email, string productId);
    }
}
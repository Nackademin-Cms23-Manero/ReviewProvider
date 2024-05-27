using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReviewProvider.Data.Contexts;
using ReviewProvider.Factories;
using ReviewProvider.Functions;
using ReviewProvider.Models;

namespace ReviewProvider.Services;

public class CreateUserReviewService : ICreateUserReviewService
{
    private readonly ILogger<CreateUserReviewService> _logger;
    private readonly DataContext _context;

    public CreateUserReviewService(ILogger<CreateUserReviewService> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<UserReviewRequest> UnpackUserReviewRequest(HttpRequest req)
    {
        try
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            if (!string.IsNullOrEmpty(body))
            {
                var userReviewRequest = JsonConvert.DeserializeObject<UserReviewRequest>(body);
                if (userReviewRequest != null)
                {
                    return userReviewRequest;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR : CreateUserReview.UnpackUserReviewRequest() :: {ex.Message}");
        }
        return null!;
    }

    public async Task<bool> UserExists(string email, string productId)
    {
        try
        {
            if (email != null)
            {
                var exists = await _context.UserReviews.AnyAsync(x => x.Email == email && x.ProductId == productId);
                if (exists)
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR : CreateUserReview.SaveUserReviewRequest() :: {ex.Message}");
        }
        return false;
    }

    public async Task<bool> SaveUserReviewRequest(UserReviewRequest userReviewRequest)
    {
        try
        {
            if (userReviewRequest != null)
            {
                var ratingEntity = RatingFactory.Create(userReviewRequest);
                if (ratingEntity != null)
                {
                    var ratingEntityResult = (await _context.Ratings.AddAsync(ratingEntity)).Entity;
                    await _context.SaveChangesAsync();
                    if (ratingEntityResult != null)
                    {
                        var userReviewEntity = UserReviewFactory.Create(userReviewRequest, ratingEntityResult.Id);
                        if (userReviewEntity != null)
                        {
                            var userReviewResult = await _context.UserReviews.AddAsync(userReviewEntity);
                            await _context.SaveChangesAsync();
                            if (userReviewResult != null)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR : CreateUserReview.SaveUserReviewRequest() :: {ex.Message}");
        }
        return false;
    }
}
